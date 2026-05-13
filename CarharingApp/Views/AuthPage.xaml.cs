using System.Data.Entity;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CarharingApp;

namespace CarharingApp.Views
{
    public partial class AuthPage : Window
    {
        private Image firstButton;
        private bool isPuzzleSolved = false;

        public AuthPage()
        {
            InitializeComponent();
            LoadPuzzle();
        }

        private void LoadPuzzle()
        {
            var rnd = new Random();
            var pices = Enumerable.Range(1, 4).ToList();
            pices = pices.OrderBy(x => rnd.Next()).ToList();
            pices.ForEach(x =>
            {
                var img = new Image
                {
                    Source = new BitmapImage(new Uri($"Images/{x}.png", UriKind.Relative)),
                    Tag = x,
                    Stretch = Stretch.Fill
                };
                img.MouseLeftButtonUp += Pices_Click;
                PuzzleGrid.Children.Add(img);
            });
        }

        private void CheckPuzzle()
        {
            if (PuzzleGrid.Children.OfType<Image>()
                    .Select((img, i) => i + 1 == (int)img.Tag)
                    .All(x => x))
            {
                isPuzzleSolved = true;
                PuzzleStatusText.Text = "Пазл собран!";
                PuzzleStatusText.Foreground = Brushes.Green;
            }
        }
        private void Pices_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image clicked)
            {
                if (firstButton == null)
                {
                    firstButton = clicked;
                    firstButton.Opacity = 0.5;
                    return;
                }
                if (clicked != firstButton)
                {
                    (firstButton.Source, clicked.Source) = (clicked.Source, firstButton.Source);
                    (firstButton.Tag, clicked.Tag) = (clicked.Tag, firstButton.Tag);
                }
                firstButton.Opacity = 1;
                firstButton = null;
                CheckPuzzle();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isPuzzleSolved)
            {
                MessageBox.Show("Сначала соберите пазл!", "Капча", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password;

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

            try
            {
                using (var context = new CarsharingDBEntities())
                {
                    var user = context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

                    if (user == null)
                    {
                        MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        PasswordBox.Clear();
                        return;
                    }

                    if (user.IsLocked == true)
                    {
                        MessageBox.Show("Ваша учётная запись заблокирована!\nОбратитесь к администратору.", "Доступ запрещён", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show($"Добро пожаловать!{user.FullName}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    if (user.RoleId == 1)
                    {
                        AdminPage adminPage = new AdminPage();
                        adminPage.Show();
                    }
                    else
                    {
                        UserPage userPage = new UserPage();
                        userPage.Show();
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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