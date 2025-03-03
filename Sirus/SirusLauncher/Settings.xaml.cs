using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using Microsoft.Win32;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SirusLauncher
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем и настраиваем диалог выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Выберите файл",
                Filter = "Все файлы (*.*)|*.*" // Укажите фильтр, если нужно
            };

            // Показываем диалог и проверяем, был ли выбран файл
            if (openFileDialog.ShowDialog() == true)
            {
                // Отображаем путь к выбранному файлу в текстовом поле
                FilePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = FindPathTextBox.Text;

            // Проверяем, существует ли файл
            if (System.IO.File.Exists(filePath))
            {
                // Открываем проводник с указанным файлом
                Process.Start(new ProcessStartInfo("explorer.exe", $"/select,\"{filePath}\"") { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("Файл не найден. Пожалуйста, проверьте путь.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenWebsiteButton_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://sirus.one/?utm_source=youtube&utm_medium=youtube";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show(); // Открываем главное окно
        }
    }
}
