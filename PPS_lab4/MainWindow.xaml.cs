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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PPS_lab4.Windows;
using PPS_lab4.Entities;

namespace PPS_lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        #region Клики

        private void loginBut_Click(object sender, RoutedEventArgs e)
        {
            TaskManager manager = new TaskManager();

            // Поиск аккаунта пользователя в базе
            Account currUser = (manager.Account.Where(acc => acc.Login == loginTbox.Text)).FirstOrDefault();
            // Проверка пароля и регистрация
            if (currUser != null && currUser.Pass == passTbox.Text)
            {
                TasksWindow window = new TasksWindow() { Owner = this };
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль");
            }
        }

        private void regBut_Click(object sender, RoutedEventArgs e)
        {
            RegWindow window = new RegWindow() { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            this.Visibility = Visibility.Hidden;
            window.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        #endregion
    }
}
