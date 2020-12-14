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
using System.Data.Entity;
using Microsoft.Win32;
using System.IO;
namespace Cakes
{
    /// <summary>
    /// Логика взаимодействия для Ingredients_page.xaml
    /// </summary>
    public partial class Ingredients_page : Window
    {
        public Ingredients_page()
        {
            InitializeComponent();
        }

        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            Close();
        } //Закрытие формы

        private void Выбрать_Click(object sender, RoutedEventArgs e)
        {
            CakesEntities db = new CakesEntities();
            db.Ингредиенты.Load();
            var query =
            from t in db.Ингредиенты.Where(p=> p.Дата == Дата.SelectedDate)
            select new{ t.Артикул, t.Наименование, t.Количество, t.Единицы_измерения, t.Цена, t.Поставщик };
            ShowInstruments.ItemsSource = query.ToList();
        }// Вывод таблицы и выборка по дате.

        private void Изменить_Click(object sender, RoutedEventArgs e)
        {
            Edit_Ingredients edit_Ingredients = new Edit_Ingredients();
            edit_Ingredients.Show();
        }

        private void Удалить_Click(object sender, RoutedEventArgs e)
        {
            DeleteIngredient_page deleteIngredient_Page = new DeleteIngredient_page();
            deleteIngredient_Page.Show();
        }
    }
}
