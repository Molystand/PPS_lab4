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

            // При успешной валидации логина и пароля новый аккаунт добавляется в базу
            if (!string.IsNullOrWhiteSpace(loginTbox.Text) && !string.IsNullOrWhiteSpace(passTbox.Text) &&
                passTbox.Text == passConfirmTbox.Text)
            {
                manager.Account.Add(new Account()
                {
                    Login = loginTbox.Text,
                    Pass  = passTbox.Text
                });
                manager.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный формат логина/пароля");
            }
        }
    }
}
