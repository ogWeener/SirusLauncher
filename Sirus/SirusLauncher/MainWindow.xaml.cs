using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SirusLauncher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<string> imagePaths;
        private int currentIndex;
        private readonly DispatcherTimer timer;
        private int progressValue;

        public bool isLogIn { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(100) // Обновление каждые 100 мс
            };
            timer.Tick += Timer_Tick;

            imagePaths = new List<string>
            {
                //изображения в обновлениях
                "фото обновление.png",
                "обнова 2.png",
                "обнова 3.png"
            };

            currentIndex = 0;
            isLogIn = false;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //ссылка на свойство Tag элемента
            string url = (sender as FrameworkElement)?.Tag as string;

            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось открыть ссылку: " + ex.Message);
                }
            }
        }

        private void UpdateImage()
        {
            BitmapImage bitmap = new BitmapImage(new Uri(imagePaths[currentIndex], UriKind.Relative));
            MainImage.Source = bitmap;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            currentIndex++;
            if (currentIndex >= imagePaths.Count)
            {
                currentIndex = 0;
            }
            UpdateImage();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = imagePaths.Count - 1;
            }
            UpdateImage();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.Visibility = Visibility.Hidden;

            ProgressBar.Visibility = Visibility.Visible;
            BeginButton.Visibility = Visibility.Hidden;

            // Сбрасываем значение прогресса
            progressValue = 0;
            ProgressBar.Value = progressValue;

            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Увеличиваем значение прогресса
            progressValue += 1;
            ProgressBar.Value = progressValue;

            if (progressValue >= 100)
            {
                timer.Stop();

                // Возвращаем кнопки в исходное состояние
                StartButton.Visibility = Visibility.Visible;
                BeginButton.Visibility = Visibility.Visible;
                ProgressBar.Visibility = Visibility.Hidden;
            }
        }
        private void Accaunt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isLogIn == true)
            {
                Authorized popsup = new Authorized();
                popsup.OnToggleLogin += ToggleLogin;
                popsup.ShowDialog();
            }
            else
            {
                Accaunt popup = new Accaunt();
                popup.OnToggleLogin += ToggleLogin;
                popup.ShowDialog(); // создание модального окна
            }
        }

        public void ToggleLogin()
        {
            isLogIn = !isLogIn;
        }

        private void Settings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Settings sett = new Settings();
            sett.Show(); // Открываем окно настроек
            this.Hide(); // Скрываем главное окно
        }


    }
}
