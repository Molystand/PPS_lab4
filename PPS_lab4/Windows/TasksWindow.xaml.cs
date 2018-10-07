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

namespace PPS_lab4.Windows
{
    /// <summary>
    /// Логика взаимодействия для TasksWindow.xaml
    /// </summary>
    public partial class TasksWindow : Window
    {
        public TasksWindow()
        {
            InitializeComponent();
        }

        private void tasksDgrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void tasksDgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // Добавление новой задачи
        private void addTaskBut_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow window = new TaskWindow() { Owner = this };
            window.ShowDialog();
        }
    }
}
