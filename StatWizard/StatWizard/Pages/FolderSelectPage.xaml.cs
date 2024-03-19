using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using WinForms = System.Windows.Forms;

namespace StatWizard.Pages
{
    /// <summary>
    /// Interaction logic for FolderSelectPage.xaml
    /// </summary>
    public partial class FolderSelectPage : Page
    {
        MainWindow mainWindow;
        string fileDirectory, folderDirectory;

        public FolderSelectPage()
        {
            InitializeComponent();
        }
        public FolderSelectPage(MainWindow _mainWindow)
        {
            InitializeComponent();

            mainWindow = _mainWindow;
        }

        private void FolderSelectButton_Click(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog folderBrowserDialog = new WinForms.FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = false;
            folderBrowserDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            WinForms.DialogResult folderSelectResult = folderBrowserDialog.ShowDialog();

            folderDirectory = folderBrowserDialog.SelectedPath;
            FolderDirectoryTextbox.Text = folderDirectory;
        }

        private void FileSelectButton_Click(object sender, RoutedEventArgs e)
        {
            WinForms.OpenFileDialog fileBrowserDialog = new WinForms.OpenFileDialog();
            fileBrowserDialog.Multiselect = false;
            fileBrowserDialog.Filter = "Comma-separated values file (*.csv)|*.csv*";
            fileBrowserDialog.DefaultExt = ".csv";
            fileBrowserDialog.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            fileBrowserDialog.ShowDialog();

            fileDirectory = fileBrowserDialog.FileName;
            FileDirectoryTextbox.Text = fileDirectory;
        }

        private async void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            if (folderDirectory.Length != 0 && fileDirectory.Length != 0)
            {
                LoadingProgressBar.Visibility = Visibility.Visible;
                ContinueButton.Content = "Loading...";

                mainWindow.stopwatch.Start();

                await Task.Run(() => LoadData());
                
                this.Dispatcher.Invoke(() =>
                {
                    //switch to the next screen
                    mainWindow.NavigationFrame.Navigate(mainWindow.pages.resultsPage);   
                });
            }
        }

        private void LoadData()
        {
            //LoadDataSetALinear();
            //LoadDataSetBLinear();
            LoadDataSetAParallel();
            LoadDataSetBParallel();
        }

        public void LoadDataSetALinear()
        {
            string storeCodesFilePath = fileDirectory;
            string[] storeCodesData = File.ReadAllLines(storeCodesFilePath);
            string[] fileNames = Directory.GetFiles(folderDirectory);

            foreach (var storeData in storeCodesData)
            {
                string[] storeDataSplit = storeData.Split(',');
                Store store = new Store { StoreCode = storeDataSplit[0], StoreLocation = storeDataSplit[1] };
                if (!mainWindow.sortedData.stores.ContainsKey(store.StoreCode))
                    mainWindow.sortedData.stores.TryAdd(store.StoreCode, store);

                //storeDataSplit[0] = store code
                //storeDataSplit[1] = store location
            }

            foreach (var filePath in fileNames)
            {
                string fileNameExt = System.IO.Path.GetFileName(filePath);
                string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);

                string[] fileNameSplit = fileName.Split('_');
                Store store = mainWindow.sortedData.stores[fileNameSplit[0]];
                Date date = new Date { Week = Convert.ToInt32(fileNameSplit[1]), Year = Convert.ToInt32(fileNameSplit[2]) };
                mainWindow.sortedData.dates.Add(date);
                //fileNameSplit[0] = store code
                //fileNameSplit[1] = week number
                //fileNameSplit[2] = year

                string[] orderData = File.ReadAllLines(folderDirectory + @"\" + fileNameExt);
                foreach (var orderInfo in orderData)
                {

                    string[] orderSplit = orderInfo.Split(',');
                    Order order = new Order
                    {
                        Store = store,
                        Date = date,
                        SupplierName = orderSplit[0],
                        SupplierType = orderSplit[1],
                        Cost = Convert.ToDouble(orderSplit[2])
                    };
                    mainWindow.sortedData.orders.Add(order);
                    //orderSplit[0] = supplier name
                    //orderSplit[1] = supplier type
                    //orderSplit[2] = cost
                }
            }
        }

        public void LoadDataSetBLinear()
        {
            ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();
            
            double value = 0;

            foreach (Order order in mainWindow.sortedData.orders)
            {
                if (!mainWindow.sortedData.supplierTypeCosts.ContainsKey(order.SupplierType))
                {
                    mainWindow.sortedData.supplierTypeCosts.TryAdd(order.SupplierType, 0);
                }

                if (!mainWindow.sortedData.storeCosts.ContainsKey(order.Store.StoreLocation))
                {
                    mainWindow.sortedData.storeCosts.TryAdd(order.Store.StoreLocation, 0);
                }

                if (!mainWindow.sortedData.supplierCosts.ContainsKey(order.SupplierName))
                {
                    mainWindow.sortedData.supplierCosts.TryAdd(order.SupplierName, 0);
                }

                mainWindow.sortedData.supplierTypeCosts.TryGetValue(order.SupplierType, out value);
                mainWindow.sortedData.supplierTypeCosts.TryUpdate(order.SupplierType, value + order.Cost, value);

                mainWindow.sortedData.storeCosts.TryGetValue(order.Store.StoreLocation, out value);
                mainWindow.sortedData.storeCosts.TryUpdate(order.Store.StoreLocation, value + order.Cost, value);

                mainWindow.sortedData.supplierCosts.TryGetValue(order.SupplierName, out value);
                mainWindow.sortedData.supplierCosts.TryUpdate(order.SupplierName, value + order.Cost, value);

                mainWindow.sortedData.totalCost += order.Cost;
            }
        }

        public void LoadDataSetAParallel()
        {
            ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();

            string storeCodesFilePath = fileDirectory;
            string[] storeCodesData = File.ReadAllLines(storeCodesFilePath);
            string[] fileNames = Directory.GetFiles(folderDirectory);

            Parallel.ForEach(storeCodesData, storeData =>
            {
                rwls.EnterWriteLock();

                string[] storeDataSplit = storeData.Split(',');
                Store store = new Store { StoreCode = storeDataSplit[0], StoreLocation = storeDataSplit[1] };
                if (!mainWindow.sortedData.stores.ContainsKey(store.StoreCode))
                    mainWindow.sortedData.stores.TryAdd(store.StoreCode, store);

                //storeDataSplit[0] = store code
                //storeDataSplit[1] = store location

                rwls.ExitWriteLock();
            });

            Parallel.ForEach(fileNames, filePath =>
            {
                rwls.EnterWriteLock();

                string fileNameExt = System.IO.Path.GetFileName(filePath);
                string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);

                string[] fileNameSplit = fileName.Split('_');
                Store store = mainWindow.sortedData.stores[fileNameSplit[0]];
                Date date = new Date { Week = Convert.ToInt32(fileNameSplit[1]), Year = Convert.ToInt32(fileNameSplit[2]) };
                mainWindow.sortedData.dates.Add(date);
                //fileNameSplit[0] = store code
                //fileNameSplit[1] = week number
                //fileNameSplit[2] = year

                rwls.ExitWriteLock();

                string[] orderData = File.ReadAllLines(folderDirectory + @"\" + fileNameExt);
                foreach (var orderInfo in orderData)
                {
                    rwls.EnterWriteLock();

                    string[] orderSplit = orderInfo.Split(',');
                    Order order = new Order
                    {
                        Store = store,
                        Date = date,
                        SupplierName = orderSplit[0],
                        SupplierType = orderSplit[1],
                        Cost = Convert.ToDouble(orderSplit[2])
                    };
                    mainWindow.sortedData.orders.Add(order);
                    //orderSplit[0] = supplier name
                    //orderSplit[1] = supplier type
                    //orderSplit[2] = cost

                    rwls.ExitWriteLock();
                }
            });
        }

        public void LoadDataSetBParallel()
        {
            ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();

            double value = 0;

            Parallel.ForEach(mainWindow.sortedData.orders, order =>
            {
                rwls.EnterWriteLock();

                if (!mainWindow.sortedData.supplierTypeCosts.ContainsKey(order.SupplierType))
                {
                    mainWindow.sortedData.supplierTypeCosts.TryAdd(order.SupplierType, 0);
                }

                if (!mainWindow.sortedData.storeCosts.ContainsKey(order.Store.StoreLocation))
                {
                    mainWindow.sortedData.storeCosts.TryAdd(order.Store.StoreLocation, 0);
                }

                if (!mainWindow.sortedData.supplierCosts.ContainsKey(order.SupplierName))
                {
                    mainWindow.sortedData.supplierCosts.TryAdd(order.SupplierName, 0);
                }

                mainWindow.sortedData.supplierTypeCosts.TryGetValue(order.SupplierType, out value);
                mainWindow.sortedData.supplierTypeCosts.TryUpdate(order.SupplierType, value + order.Cost, value);

                mainWindow.sortedData.storeCosts.TryGetValue(order.Store.StoreLocation, out value);
                mainWindow.sortedData.storeCosts.TryUpdate(order.Store.StoreLocation, value + order.Cost, value);

                mainWindow.sortedData.supplierCosts.TryGetValue(order.SupplierName, out value);
                mainWindow.sortedData.supplierCosts.TryUpdate(order.SupplierName, value + order.Cost, value);

                mainWindow.sortedData.totalCost += order.Cost;

                rwls.ExitWriteLock();
            });
        }
    }
}
