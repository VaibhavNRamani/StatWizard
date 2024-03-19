using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StatWizard.Pages
{
    /// <summary>
    /// Interaction logic for AdditionalStatsPage.xaml
    /// </summary>
    public partial class AdditionalStatsPage : Page
    {
        MainWindow mainWindow;
        public AdditionalStatsPage()
        {
            InitializeComponent();
        }
        
        public AdditionalStatsPage(MainWindow _mainWindow)
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
            KeyValuePair<string, double> lowestCostStore = mainWindow.sortedData.storeCosts.First();
            KeyValuePair<string, double> highestCostStore = mainWindow.sortedData.storeCosts.First();

            foreach (KeyValuePair<string, double> storeCost in mainWindow.sortedData.storeCosts)
            { 
                if (storeCost.Value < lowestCostStore.Value)
                {
                    lowestCostStore = storeCost;
                }

                else if (storeCost.Value > highestCostStore.Value)
                {
                    highestCostStore = storeCost;
                }
            }

            KeyValuePair<string, double> lowestCostSupplier = mainWindow.sortedData.supplierCosts.First();
            KeyValuePair<string, double> highestCostSupplier = mainWindow.sortedData.supplierCosts.First();

            foreach (KeyValuePair<string, double> supplierCost in mainWindow.sortedData.supplierCosts)
            {
                if (supplierCost.Value < lowestCostSupplier.Value)
                {
                    lowestCostSupplier = supplierCost;
                }

                else if (supplierCost.Value > highestCostSupplier.Value)
                {
                    highestCostSupplier = supplierCost;
                }
            }

            List<double> storeCostValues = mainWindow.sortedData.storeCosts.Values.ToList();
            List<double> supplierCostValues = mainWindow.sortedData.supplierCosts.Values.ToList();

            Stat1Textblock.Text = "The average cost of orders per store is £" + storeCostValues.Average() + ".";
            Stat2Textblock.Text = "Of these, the store with the highest cost was " + highestCostStore.Key + " with a total order cost of £" + highestCostStore.Value + ".";
            Stat3Textblock.Text = "Also, the store with the lowest cost was " + lowestCostStore.Key + " with a total order cost of £" + lowestCostStore.Value + ".";
                     
            Stat4Textblock.Text = "The average cost of orders per supplier is £" + supplierCostValues.Average() + ".";
            Stat5Textblock.Text = "Of these, the supplier with the highest cost was " + highestCostSupplier.Key + " with a total order cost of £" + highestCostSupplier.Value + ".";
            Stat6Textblock.Text = "Also, the supplier with the lowest cost was " + lowestCostSupplier.Key + " with a total order cost of £" + lowestCostSupplier.Value + ".";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigationFrame.Navigate(mainWindow.pages.resultsPage);
        }
    }
}
