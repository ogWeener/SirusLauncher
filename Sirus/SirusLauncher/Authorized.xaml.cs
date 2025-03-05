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

namespace SirusLauncher
{
    /// <summary>
    /// Логика взаимодействия для Authorized.xaml
    /// </summary>
    public partial class Authorized : Window
    {
        public event Action OnToggleLogin;

        public Authorized()
        {
            InitializeComponent();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            OnToggleLogin?.Invoke();
            Accaunt ac = new Accaunt();
            ac.Show();
            this.Hide();
        }
    }
}
