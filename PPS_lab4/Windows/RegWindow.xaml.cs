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
using PPS_lab4.Entities;

namespace PPS_lab4.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }



        private void regBut_Click(object sender, RoutedEventArgs e)
        {
            TaskManager manager = new TaskManager();
            string login = loginTbox.Text;
            string pass = passTbox.Text;

            // Валидация логина/пароля
            if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(pass) &&
                pass == passConfirmTbox.Text)
            {
                // Есть ли аккаунт в базе
                if (Account.Get(login) == null)
                {
                    manager.Account.Add(new Account()
                    {
                        Login = login,
                        Pass = pass
                    });
                    manager.SaveChanges();
                    MessageBox.Show($"Пользователь {login} успешно зарегистрирован");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже зарегистрирован");
                }
            }
            else
            {
                MessageBox.Show("Неверный формат логина/пароля");
            }
        }
    }
}
