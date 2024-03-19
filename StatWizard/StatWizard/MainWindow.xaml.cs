using StatWizard.Pages;
using System;
using System.Collections.Concurrent;
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
using System.Diagnostics;

namespace StatWizard
{
    public class Store
    {
        public string StoreCode { get; set; }
        public string StoreLocation { get; set; }
    }

    public class Order
    {
        public Store Store { get; set; }
        public Date Date { get; set; }
        public string SupplierName { get; set; }
        public string SupplierType { get; set; }
        public double Cost { get; set; }
    }

    public class Date
    {
        public int Week { get; set; }
        public int Year { get; set; }
    }

    public class SortedData
    {
        public ConcurrentDictionary<string, Store> stores;
        public HashSet<Date> dates;
        public List<Order> orders;

        public ConcurrentDictionary<string, double> supplierTypeCosts = new ConcurrentDictionary<string, double>();
        public ConcurrentDictionary<string, double> storeCosts = new ConcurrentDictionary<string, double>();
        public ConcurrentDictionary<string, double> supplierCosts = new ConcurrentDictionary<string, double>();
        public double totalCost;

        public string[] weeks;
        public string[] years;

        public SortedData()
        {
            dates = new HashSet<Date>();
            orders = new List<Order>();
            stores = new ConcurrentDictionary<string, Store>();

            supplierTypeCosts = new ConcurrentDictionary<string, double>();
            storeCosts = new ConcurrentDictionary<string, double>();
            supplierCosts = new ConcurrentDictionary<string, double>();
            totalCost = 0;

            weeks = new string[52];

            for (int i = 0; i < weeks.Length; i++)
            {
                weeks[i] = (i + 1).ToString();
            }

            years = new string[]{ "2013", "2014" };
        }
    }

    public class AllPages
    {
        public WelcomePage welcomePage;
        public FolderSelectPage folderSelectPage;
        public ResultsPage resultsPage;
        public GeneralOverviewPage generalOverviewPage;
        public ByStorePage byStorePage;
        public BySupplierPage bySupplierPage;
        public BySupplierTypePage bySupplierTypePage;
        public ByWeekPage byWeekPage;
        public AdditionalStatsPage additionalStatsPage;
        
        public AllPages(MainWindow _mainWindow) 
        {
            welcomePage = new WelcomePage(_mainWindow);
            folderSelectPage = new FolderSelectPage(_mainWindow);
            resultsPage = new ResultsPage(_mainWindow);
            generalOverviewPage = new GeneralOverviewPage(_mainWindow);
            byStorePage = new ByStorePage(_mainWindow);
            bySupplierPage = new BySupplierPage(_mainWindow);
            bySupplierTypePage = new BySupplierTypePage(_mainWindow);
            byWeekPage = new ByWeekPage(_mainWindow);
            additionalStatsPage = new AdditionalStatsPage(_mainWindow);
        }
    }
    public partial class MainWindow : Window
    {
        public AllPages pages;
        Frame navigationFrame;
        public Stopwatch stopwatch;
        public SortedData sortedData;

        public MainWindow()
        {
            InitializeComponent();

            sortedData = new SortedData();
            navigationFrame = NavigationFrame;
            stopwatch = new Stopwatch();
            pages = new AllPages(this);

            navigationFrame.NavigationService.Navigate(pages.welcomePage);
        }
    }
}
