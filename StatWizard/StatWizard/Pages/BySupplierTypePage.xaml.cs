using System;
using System.Collections.Concurrent;
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
    /// Interaction logic for BySupplierTypePage.xaml
    /// </summary>
    public partial class BySupplierTypePage : Page
    {
        MainWindow mainWindow;
        public BySupplierTypePage()
        {
            InitializeComponent();
        }

        public BySupplierTypePage(MainWindow _mainWindow)
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
            SupplierTypesComboBox.ItemsSource = mainWindow.sortedData.supplierTypeCosts.Keys.ToList();
            WeekComboBox.ItemsSource = mainWindow.sortedData.weeks;
            YearComboBox.ItemsSource = mainWindow.sortedData.years;

            SupplierTypeSeries.ItemsSource = mainWindow.sortedData.supplierTypeCosts;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigationFrame.Navigate(mainWindow.pages.resultsPage);
        }

        private void QuerySupplierTypeCostTextblock_Click(object sender, RoutedEventArgs e)
        {
            if (SupplierTypesComboBox.Text != "")
            {
                string supplierTypeToQuery = SupplierTypesComboBox.Text;

                Stopwatch stopwatch = Stopwatch.StartNew();

                double value = 0;
                mainWindow.sortedData.supplierTypeCosts.TryGetValue(supplierTypeToQuery, out value);

                stopwatch.Stop();

                SupplierTypeTotalCostTextblock.Text = "The total cost of orders for this supplier type is £" + Math.Round(value, 2) + ". Time elapsed: " + stopwatch.Elapsed.TotalSeconds.ToString() + " seconds.";
            }
        }

        private void QueryByWeekButton_Click(object sender, RoutedEventArgs e)
        {
            double cost = 0;

            if (SupplierTypesComboBox.Text != "" && WeekComboBox.Text != "" && YearComboBox.Text != "")
            {
                string supplierTypeToQuery = SupplierTypesComboBox.Text;
                int week = Convert.ToInt16(WeekComboBox.Text);
                int year = Convert.ToInt16(YearComboBox.Text);

                Stopwatch stopwatch = Stopwatch.StartNew();

                foreach (Order order in mainWindow.sortedData.orders)
                {
                    if (order.SupplierType == supplierTypeToQuery && order.Date.Week == week && order.Date.Year == year)
                    {
                        cost += order.Cost;
                    }
                }

                stopwatch.Stop();

                CostByWeekTextblock.Text = "The total cost of orders for this supplier type for this week is £" + Math.Round(cost, 2) + ". Time elapsed: " + stopwatch.Elapsed.TotalSeconds.ToString() + " seconds.";
            }
        }
    }
}
