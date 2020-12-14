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
    /// Логика взаимодействия для Edit_Ingredients.xaml
    /// </summary>
    public partial class Edit_Ingredients : Window
    {
        public Edit_Ingredients()
        {
            InitializeComponent();
        }

        private void Ок_Click(object sender, RoutedEventArgs e)
        {
            string Articul = АртикулBox.Text;
            
            CakesEntities db = new CakesEntities();
            db.Ингредиенты.Load(); //Подключение к базе данных.
            var user = db.Ингредиенты
                .Where(u => u.Артикул == Articul)
                .FirstOrDefault();
            //Сравнение введенного артикуля с артикулем из бд.
            
            if (АртикулBox.Text == "")
            {
                MessageBox.Show("Введите артикул.");
            } //Проверка на наличие артикуля
            else
            {
                if ( user == null)
                {
                    MessageBox.Show("Такого артикуля нет.");
                }
                if (user != null)
                {
                    ArtTextBlock.Visibility = Visibility.Collapsed;
                    АртикулBox.Visibility = Visibility.Collapsed;
                    OK_Button.Visibility = Visibility.Collapsed;                       // Скрытие видимости первого ввода

                    НаименованиеBox.Visibility = Visibility.Visible;
                    КоличествоBox.Visibility = Visibility.Visible;
                    Ед_измеренияBox.Visibility = Visibility.Visible;
                    ЦенаBox.Visibility = Visibility.Visible;
                    ПоставщикBox.Visibility = Visibility.Visible;                      // Включение видимости Textbox'ов
                    Изменить.Visibility = Visibility.Visible;                          // Включение видимости кнопки "Изменить"
                    Наименование.Visibility = Visibility.Visible;
                    Количество.Visibility = Visibility.Visible;
                    Ед_измерения.Visibility = Visibility.Visible;
                    Цена.Visibility = Visibility.Visible;
                    Поставщик.Visibility = Visibility.Visible;                         // Включение видимости Textblock'ов

                    НаименованиеBox.Text = user.Наименование;
                    КоличествоBox.Text = Convert.ToString(user.Количество);
                    Ед_измеренияBox.Text = user.Единицы_измерения;
                    ЦенаBox.Text = Convert.ToString(user.Цена);
                    ПоставщикBox.Text = user.Поставщик;
                } 
            }

        }

        private void Изменить_Click(object sender, RoutedEventArgs e)
        {
            CakesEntities db = new CakesEntities();
            db.Ингредиенты.Load();
            var EditIngredients = db.Ингредиенты
                        .Where(u => u.Наименование == НаименованиеBox.Text )
                        .FirstOrDefault();

            if (НаименованиеBox.Text == "" || КоличествоBox.Text == "" || Ед_измеренияBox.Text == "" || ЦенаBox.Text == "" || ПоставщикBox.Text =="")
            {
                MessageBox.Show("Поля 'Наименование','Количество','Ед_измерения' и 'Цена' обязательны к заполнению!");
            } //Проверка на ввод данных
            else
            {
                if (EditIngredients != null)
                {
                    EditIngredients.Наименование = НаименованиеBox.Text;
                    EditIngredients.Количество = Convert.ToInt32(КоличествоBox.Text);
                    EditIngredients.Единицы_измерения = Ед_измеренияBox.Text;
                    EditIngredients.Цена = Convert.ToDecimal(ЦенаBox.Text);
                    EditIngredients.Поставщик = ПоставщикBox.Text;
                    db.SaveChanges();
                    MessageBox.Show("Изменения завершены успешно.");
                    Close();
                } //Внесение изменений.
            }
            
        }

        private void ЦенаBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }//ограничение ввода, вводить можно только цифры.

        private void КоличествоBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }//ограничение ввода, вводить можно только цифры.

        private void АртикулBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
