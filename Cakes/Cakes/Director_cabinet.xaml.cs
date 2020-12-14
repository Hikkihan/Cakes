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
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.Entity;
using Microsoft.Win32;
using System.IO;

namespace Cakes
{
    /// <summary>
    /// Логика взаимодействия для Director_cabinet.xaml
    /// </summary>
    public partial class Director_cabinet : Window
    {
        public Director_cabinet()
        {
            InitializeComponent();
        }

        private void Инструменты_Click(object sender, RoutedEventArgs e)
        {
            CakesEntities db = new CakesEntities();
            db.Инструменты.Load();
            var query =
            from t in db.Инструменты
            select new { t.Наименование, t.Тип_инструмента, t.Дата_покупки, t.Количество };

            ShowInstruments.ItemsSource = query.ToList();
        }

        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Ингредиенты_Click(object sender, RoutedEventArgs e)
        {
            Ingredients_page ingredients_Page = new Ingredients_page();
            ingredients_Page.Show();
        }

        private void Украшения_Click(object sender, RoutedEventArgs e)
        {
            Decoration_page decoration_Page = new Decoration_page();
            decoration_Page.Show();
        }
    }
}
