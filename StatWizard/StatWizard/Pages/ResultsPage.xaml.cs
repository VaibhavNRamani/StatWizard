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

namespace StatWizard.Pages
{
    /// <summary>
    /// Interaction logic for ResultsPage.xaml
    /// </summary>
    public partial class ResultsPage : Page
    {
        MainWindow mainWindow;

        public ResultsPage()
        {
            InitializeComponent();
        }
        
        public ResultsPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;

            this.Loaded += new RoutedEventHandler(OnLoaded);
        }

        public void OnLoaded(object sender, RoutedEventArgs e)
        {
            if(LoadCompleteTextBlock.Text == "-")
            {
                mainWindow.stopwatch.Stop();
                string timeElapsed = mainWindow.stopwatch.Elapsed.TotalSeconds.ToString();
                mainWindow.stopwatch.Reset();

                LoadCompleteTextBlock.Text = "Loading complete. Time elapsed: " + timeElapsed + " seconds";
            }

            else
            {
                LoadCompleteTextBlock.Text = "";
            }
        }

        private async void GeneralOverviewButton_Click(object sender, RoutedEventArgs e)
        {
            //await Task.Run(() => mainWindow.pages.generalOverviewPage.Load());

            //Dispatcher.Invoke(() =>
            //{
            //    mainWindow.pages.generalOverviewPage.Load();
            //    mainWindow.NavigationFrame.Navigate(mainWindow.pages.generalOverviewPage);
            //});

            //mainWindow.pages.generalOverviewPage.Load();
            mainWindow.NavigationFrame.Navigate(mainWindow.pages.generalOverviewPage);
        }

        private void ByStoreButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigationFrame.Navigate(mainWindow.pages.byStorePage);
        }

        private void BySupplierButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigationFrame.Navigate(mainWindow.pages.bySupplierPage);
        }

        private void BySupplierTypeButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigationFrame.Navigate(mainWindow.pages.bySupplierTypePage);
        }

        private void ByWeekButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigationFrame.Navigate(mainWindow.pages.byWeekPage);
        }

        private void AdditionalStatsButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigationFrame.Navigate(mainWindow.pages.additionalStatsPage);
        }
    }
}
