using System;
using System.Collections.Generic;
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
    /// Interaction logic for GeneralOverviewPage.xaml
    /// </summary>
    public partial class GeneralOverviewPage : Page
    {
        MainWindow mainWindow;

        public GeneralOverviewPage()
        {
            InitializeComponent();
        }
        public GeneralOverviewPage(MainWindow _mainWindow)
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
            TotalCostTextblock.Text = "The total cost of all orders in the data is £" + Math.Round(mainWindow.sortedData.totalCost, 2) + ".";

            StoresTextblock.Text = "Stores: (" + mainWindow.sortedData.storeCosts.Count + " total)";
            StoresListView.ItemsSource = mainWindow.sortedData.storeCosts.Keys.ToList();

            SuppliersTextblock.Text = "Suppliers: (" + mainWindow.sortedData.supplierCosts.Count + " total)";
            SuppliersListView.ItemsSource = mainWindow.sortedData.supplierCosts.Keys.ToList();

            SupplierTypesTextblock.Text = "Supplier types: (" + mainWindow.sortedData.supplierTypeCosts.Count + " total)";
            SupplierTypesListView.ItemsSource = mainWindow.sortedData.supplierTypeCosts.Keys.ToList();
        }

        private void BackButton1_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigationFrame.Navigate(mainWindow.pages.resultsPage);
        }

        public double TotalCost()
        {
            double cost = 0;

            ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();

            foreach (Order order in mainWindow.sortedData.orders)
            {
                rwls.EnterWriteLock();

                cost += order.Cost;

                rwls.ExitWriteLock();
            }

            return cost;
        }
    }
}
