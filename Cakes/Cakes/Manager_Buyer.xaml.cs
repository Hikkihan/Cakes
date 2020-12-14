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

namespace Cakes
{
    /// <summary>
    /// Логика взаимодействия для Manager_Buyer.xaml
    /// </summary>
    public partial class Manager_Buyer : Window
    {
        public Manager_Buyer()
        {
            InitializeComponent();
        }

        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
