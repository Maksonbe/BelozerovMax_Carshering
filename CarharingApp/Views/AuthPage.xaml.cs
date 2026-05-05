using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPuzzleSolved)
            {
                MessageBox.Show("Решите капчу!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

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
                MessageBox.Show("Решено!");
            }

        }


        private void Pices_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Image clicked)) return;

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


    }
}