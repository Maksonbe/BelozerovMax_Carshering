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
    /// Interaction logic for UnblockUserPage.xaml
    /// </summary>
    public partial class UnblockUserPage : Window
    {
        public UnblockUserPage()
        {
            InitializeComponent();
        }

        private void unblock_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Out5(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this.Close();
        }
    }
}
