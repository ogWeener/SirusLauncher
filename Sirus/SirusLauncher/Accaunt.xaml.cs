using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SirusLauncher
{
    /// <summary>
    /// Логика взаимодействия для Accaunt.xaml
    /// </summary>
    public partial class Accaunt : Window
    {
        public Accaunt()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string url = "https://sirus.one/#play";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void InputTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderLTextBlock.Visibility = Visibility.Collapsed;
            PlaceholderPTextBlock.Visibility = Visibility.Collapsed;
        }

        private void InputTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputLoginTextBox.Text))
            {
                PlaceholderLTextBlock.Visibility = Visibility.Visible;
            }
            if (string.IsNullOrWhiteSpace(InputPassWTextBox.Text))
            {
                PlaceholderPTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string inputLText = InputLoginTextBox.Text;
            string inputPText = InputPassWTextBox.Text;

            MessageBox.Show($"Вы ввели: {inputLText}, {inputPText}");
            MainWindow imageStart = new MainWindow();
            imageStart.AccauntImage.Visibility = Visibility.Visible;
        }
    }
}
