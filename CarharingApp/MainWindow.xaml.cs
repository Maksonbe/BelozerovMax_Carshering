using System.Windows;
using CarharingApp.Helpers;
using CarharingApp.Views;

namespace CarsharingApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CarharingApp.Views.AuthPage authPage = new CarharingApp.Views.AuthPage();
            authPage.Show();
            this.Close();

        }
    }
}