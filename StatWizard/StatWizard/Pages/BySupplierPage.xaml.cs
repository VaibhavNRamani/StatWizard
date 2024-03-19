using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Threading;

namespace StatWizard.Pages
{
    /// <summary>
    /// Interaction logic for BySupplierPage.xaml
    /// </summary>
    public partial class BySupplierPage : Page
    {
        MainWindow mainWindow;
        public BySupplierPage()
        {
            InitializeComponent();
        }
        public BySupplierPage(MainWindow _mainWindow)
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
            SuppliersCombobox.ItemsSource = mainWindow.sortedData.supplierCosts.Keys.ToList();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigationFrame.Navigate(mainWindow.pages.resultsPage);
        }

        private void QueryButton_Click(object sender, RoutedEventArgs e)
        {
            if (SuppliersCombobox.Text != "")
            {
                string supplierToQuery = SuppliersCombobox.Text;

                Stopwatch stopwatch = Stopwatch.StartNew();

                double value = 0;
                mainWindow.sortedData.supplierCosts.TryGetValue(supplierToQuery, out value);

                EditOrderChartLinear(supplierToQuery);

                stopwatch.Stop();

                SupplierCostTextblock.Text = "The total cost of orders for this supplier is £" + Math.Round(value, 2) + ". Time elapsed: " + stopwatch.Elapsed.TotalSeconds.ToString() + " seconds.";
            }
        }
        private void EditOrderChartParallel(string supplier)
        {
            ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();

            ConcurrentDictionary<int, int> Series2013Data = new ConcurrentDictionary<int, int>();
            ConcurrentDictionary<int, int> Series2014Data = new ConcurrentDictionary<int, int>();

            Parallel.For(0, 52, (i) =>
            {
                rwls.EnterWriteLock();

                Series2013Data.TryAdd(i + 1, 0);
                Series2014Data.TryAdd(i + 1, 0);

                rwls.ExitWriteLock();
            });

            Parallel.ForEach(mainWindow.sortedData.orders, order =>
            {
                rwls.EnterWriteLock();

                if (order.SupplierName == supplier)
                {
                    int value = 0;

                    if (order.Date.Year == 2013)
                    {
                        Series2013Data.TryGetValue(order.Date.Week, out value);
                        Series2013Data.TryUpdate(order.Date.Week, value + (int)order.Cost, value);
                    }

                    else if (order.Date.Year == 2014)
                    {
                        Series2014Data.TryGetValue(order.Date.Week, out value);
                        Series2014Data.TryUpdate(order.Date.Week, value + (int)order.Cost, value);
                    }
                }

                rwls.ExitWriteLock();
            });

            Series2013.ItemsSource = Series2013Data;
            Series2014.ItemsSource = Series2014Data;
        }

        private void EditOrderChartLinear(string supplier)
        {
            ConcurrentDictionary<int, int> Series2013Data = new ConcurrentDictionary<int, int>();
            ConcurrentDictionary<int, int> Series2014Data = new ConcurrentDictionary<int, int>();

            for (int i = 0; i < 52; i++)
            {
                Series2013Data.TryAdd(i + 1, 0);
                Series2014Data.TryAdd(i + 1, 0);
            }

            foreach (Order order in mainWindow.sortedData.orders)
            {
                if (order.SupplierName == supplier)
                {
                    int value = 0;

                    if (order.Date.Year == 2013)
                    {
                        Series2013Data.TryGetValue(order.Date.Week, out value);
                        Series2013Data.TryUpdate(order.Date.Week, value + (int)order.Cost, value);
                    }

                    else if (order.Date.Year == 2014)
                    {
                        Series2014Data.TryGetValue(order.Date.Week, out value);
                        Series2014Data.TryUpdate(order.Date.Week, value + (int)order.Cost, value);
                    }
                }
            }

            Series2013.ItemsSource = Series2013Data;
            Series2014.ItemsSource = Series2014Data;
        }

    }
}
