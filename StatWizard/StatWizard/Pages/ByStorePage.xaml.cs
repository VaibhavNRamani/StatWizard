using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace StatWizard.Pages
{
    /// <summary>
    /// Interaction logic for ByStorePage.xaml
    /// </summary>
    public partial class ByStorePage : Page
    {
        MainWindow mainWindow;

        public ByStorePage()
        {
            InitializeComponent();
        }
        public ByStorePage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;

            this.Loaded += new RoutedEventHandler(OnLoaded);
        }
        public void OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateScreen();
        }

        public void UpdateScreen()
        {
            WeekComboBox.ItemsSource = mainWindow.sortedData.weeks;
            YearComboBox.ItemsSource = mainWindow.sortedData.years;

            StoresComboBox.ItemsSource = mainWindow.sortedData.storeCosts.Keys;
            SupplierTypeComboBox.ItemsSource = mainWindow.sortedData.supplierTypeCosts.Keys;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigationFrame.Navigate(mainWindow.pages.resultsPage);
        }

        private void QueryStoreButton_Click(object sender, RoutedEventArgs e)
        {
            ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();

            double cost = 0;

            string storeToQuery = StoresComboBox.Text;

            if (StoresComboBox.Text != "")
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                double value = 0;
                mainWindow.sortedData.storeCosts.TryGetValue(storeToQuery, out value);

                stopwatch.Stop();

                StoreTotalCostTextblock.Text = "The total cost of orders for this store is £" + Math.Round(value, 2) + ". Time elapsed: " + stopwatch.Elapsed.TotalSeconds.ToString() + " seconds.";
            }
        }

        private void QuerySupplierTypeCostButton_Click(object sender, RoutedEventArgs e)
        {
            double cost = 0;

            if (StoresComboBox.Text != "" && SupplierTypeComboBox.Text != "")
            {
                string storeToQuery = StoresComboBox.Text;
                string supplierType = SupplierTypeComboBox.Text;
                
                Stopwatch stopwatch = Stopwatch.StartNew();

                foreach (Order order in mainWindow.sortedData.orders)
                {
                    if (order.Store.StoreLocation == storeToQuery && order.SupplierType == supplierType)
                    {
                        cost += order.Cost;
                    }
                }

                stopwatch.Stop();

                SupplierTypeCostTextblock.Text = "The total cost of orders for this store for this supplier type is £" + Math.Round(cost, 2) + ". Time elapsed: " + stopwatch.Elapsed.TotalSeconds.ToString() + " seconds.";
            }
        }

        private void QueryCostByWeekButton_Click(object sender, RoutedEventArgs e)
        {
            double cost = 0;

            if (StoresComboBox.Text != "" && SupplierTypeComboBox.Text != "" && WeekComboBox.Text != "" && YearComboBox.Text != "")
            {
                string storeToQuery = StoresComboBox.Text;
                string supplierType = SupplierTypeComboBox.Text;
                int week = Convert.ToInt16(WeekComboBox.Text);
                int year = Convert.ToInt16(YearComboBox.Text);

                Stopwatch stopwatch = Stopwatch.StartNew();

                foreach (Order order in mainWindow.sortedData.orders)
                {
                    if (order.Store.StoreLocation == storeToQuery && order.SupplierType == supplierType && order.Date.Week == week && order.Date.Year == year)
                    {
                        cost += order.Cost;
                    }
                }

                stopwatch.Stop();

                CostByWeekTextBlock.Text = "The total cost of orders for this store for this supplier type for this week is £" + Math.Round(cost, 2) + ". Time elapsed: " + stopwatch.Elapsed.TotalSeconds.ToString() + " seconds.";
            }
        }
    }
}
