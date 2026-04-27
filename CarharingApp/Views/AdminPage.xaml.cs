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
using System.Windows.Shapes;

namespace CarharingApp.Views
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            AddUserPage addUserPage = new AddUserPage();
            addUserPage.Show();

            this.Close();

        }
        private void Logout(object sender, RoutedEventArgs e)
        {
            AuthPage authPage = new AuthPage();
            authPage.Show();
            this.Close();
        }
        private void UnBlock(object sender, RoutedEventArgs e)
        {
            UnblockUserPage unblockUserPage = new UnblockUserPage();
            unblockUserPage.Show();
            this.Close();
        }
    }
}
