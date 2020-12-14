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
using System.Text.RegularExpressions;

namespace Cakes
{
    /// <summary>
    /// Логика взаимодействия для DeleteIngredient_page.xaml
    /// </summary>
    public partial class DeleteIngredient_page : Window
    {
        public DeleteIngredient_page()
        {
            InitializeComponent();
        }


        private void АртикулBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Удалить_Click(object sender, RoutedEventArgs e)
        {
            if (АртикулBox.Text == "")
            {
                MessageBox.Show("Сначало введите Артикул.");
            } //Проверка на ввод данных
            else
            {
                string ID = АртикулBox.Text; //Подключение к бд
                CakesEntities db = new CakesEntities();
                db.Ингредиенты.Load();
                var DeleteInfo = db.Ингредиенты
                        .Where(u => u.Артикул == ID)
                        .FirstOrDefault();

                if (DeleteInfo == null)
                {
                    MessageBox.Show("Данные с таким ID не существуют.");
                } //Проверка на наличие ID в базе
                if (АртикулBox.Text != "" && DeleteInfo != null)
                {
                    db.Ингредиенты.Remove(DeleteInfo);
                    db.SaveChanges();
                    MessageBox.Show("Данные успешно удалены.");
                    Close();
                } //Удаление данных по ID, если они существуют.
            }
        }
    }
}
