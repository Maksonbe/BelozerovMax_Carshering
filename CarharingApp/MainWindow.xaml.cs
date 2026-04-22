using System.Windows;
using CarsharingApp.Helpers;
using CarsharingApp.Views;

namespace CarsharingApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigationHelper.MainFrame = MainFrame;
            NavigationHelper.MainFrame.Navigate(new AuthPage());
        }
    }
}