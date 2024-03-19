using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace StatWizard.Pages
{
    /// <summary>
    /// Interaction logic for ByWeekPage.xaml
    /// </summary>
    public partial class ByWeekPage : Page
    {
        MainWindow mainWindow;
        public ByWeekPage()
        {
            InitializeComponent();
        }
        
        public ByWeekPage(MainWindow _mainWindow)
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
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigationFrame.Navigate(mainWindow.pages.resultsPage);
        }

        private void QueryByDateButton_Click(object sender, RoutedEventArgs e)
        {
            double cost = 0;

            if (WeekComboBox.Text != "" && YearComboBox.Text != "")
            {
                int week = Convert.ToInt16(WeekComboBox.Text);
                int year = Convert.ToInt16(YearComboBox.Text);

                Stopwatch stopwatch = Stopwatch.StartNew();

                foreach (Order order in mainWindow.sortedData.orders)
                {
                    if (order.Date.Week == week && order.Date.Year == year)
                    {
                        cost += order.Cost;
                    }
                }

                stopwatch.Stop();

                CostByDateTextblock.Text = "The total cost of orders for this week is £" + Math.Round(cost, 2) + ". Time elapsed: " + stopwatch.Elapsed.TotalSeconds.ToString() + " seconds.";
            }
        }

        private void QueryByStoreButton_Click(object sender, RoutedEventArgs e)
        {
            double cost = 0;

            if (StoresComboBox.Text != "" && WeekComboBox.Text != "" && YearComboBox.Text != "")
            {
                string storeToQuery = StoresComboBox.Text;
                int week = Convert.ToInt16(WeekComboBox.Text);
                int year = Convert.ToInt16(YearComboBox.Text);

                Stopwatch stopwatch = Stopwatch.StartNew();

                foreach (Order order in mainWindow.sortedData.orders)
                {
                    if (order.Store.StoreLocation == storeToQuery && order.Date.Week == week && order.Date.Year == year)
                    {
                        cost += order.Cost;
                    }
                }

                stopwatch.Stop();

                CostByStoreTextblock.Text = "The total cost of orders for this store for this week is £" + Math.Round(cost, 2) + ". Time elapsed: " + stopwatch.Elapsed.TotalSeconds.ToString() + " seconds.";
            }
        }
    }
}
