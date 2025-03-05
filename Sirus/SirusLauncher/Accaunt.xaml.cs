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
        string login = "Leroy Jenkins";
        string password = "12345";

        public event Action OnToggleLogin;

        public Accaunt()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string url = "https://sirus.one/#play";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string Ulogin = loginTextBox.Text; // Получаем введённый логин
            string Upassword = passwordBox.Password; //Получаем введённый пороль
            if (login == Ulogin && Upassword != password)
            {
                MessageBox.Show("Неправильный пороль! Повторите попытку.");
            }
            else if (login != Ulogin)
            {
                MessageBox.Show("Не найден пользователь. Проверьте верность написания логина.");
            }
            else if (login == Ulogin && password == Upassword)
            {
                OnToggleLogin?.Invoke();
                Authorized aut = new Authorized();
                aut.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверно введены данные. Повторите попытку.");
            }
        }
    }
}
