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
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        MainWindow mainWindow;

        public WelcomePage()
        {
            InitializeComponent();
        }

        public WelcomePage(MainWindow _mainWindow)
        {
            InitializeComponent();
            
            mainWindow = _mainWindow;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigationFrame.Navigate(mainWindow.pages.folderSelectPage);
        }
    }
}
