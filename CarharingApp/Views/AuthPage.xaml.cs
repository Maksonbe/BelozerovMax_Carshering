using System.Windows;

namespace CarharingApp.Views
{
    public partial class AuthPage : Window
    {

        public AuthPage()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Введите логин!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (login == "admin" && password == "admin123")
            {
                MessageBox.Show("Вы успешно авторизовались!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                AdminPage adminPage = new AdminPage();
                adminPage.Show();

                this.Close();
            }
            else if (login == "user" && password == "user123")
            {
                MessageBox.Show("Вы успешно авторизовались!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                UserPage userPage = new UserPage();
                userPage.Show();

                this.Close();
            }

        }
        private void TestApi_Click(object sender, RoutedEventArgs e)
        {
            ApiPage apiPage = new ApiPage();
            apiPage.Show();

            this.Close();

        }
    }
}