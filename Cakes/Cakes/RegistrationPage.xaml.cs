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
using System.Text.RegularExpressions;
namespace Cakes
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Зарегистрироваться_Click(object sender, RoutedEventArgs e)
        {

            string Login = LoginBox.Text;
            string Password = PassBox.Password;
            string Female = FemaleBox.Text;
            string Name = NameBox.Text;
            string Picture = PictureBox.Text;

            CakesEntities db = new CakesEntities();
            db.Пользователи.Load(); //Подключение к базе данных
            var user = db.Пользователи
                .Where(u => u.Login == Login)
                .FirstOrDefault();

            if (user != null)
            {
                MessageBox.Show("Этот логин уже занят.");
            }  //Проверка на наличие уже существующего пользователя.
            if (Login == "" || Password == "" || Female == "" || Name == "")
            {
                MessageBox.Show("Поля 'Логин','Пароль','Имя','Фамилия и отчество', обязательны к заполнению!");
            }  //Проверка на заполнение полей
            else
            {
                if (Password == Login)
                {
                    MessageBox.Show("Ваш пароль не должен совпадать с введеным логином.");
                } // Проверка совпадения логина и пароля
                else
                {
                    if (Password.Length < 5)
                    {
                        MessageBox.Show("Пароль должен содержать от 5 до 20 символов.");
                    } // Проверка на условия количества символов в пароле.
                    else
                    {
                        if (Regex.IsMatch(Password, @"[А-ЯЁ]"))
                        {
                            MessageBox.Show("Пароль должен не должен содержать кириллицу.");
                        } // Проверка на кириллицу в пароле.
                        else
                        {
                            if ((user == null) && Login != "" && Password != "" && Female != "" && Name != ""
                            && Regex.IsMatch(Password, @"[a-z]") && Regex.IsMatch(Password, @"[A-Z]"))
                            {
                                user = new Пользователи();
                                user.Login = Login;
                                user.Password = Password;
                                user.Фамилия = Female;
                                user.Имя_Отчество = Name;
                                user.Role = "Заказчик";
                                db.Пользователи.Add(user);
                                db.SaveChanges();
                                MessageBox.Show("Регистрация завершена успешно.");
                                Close();
                            } // Сохранение нового пользователя.
                            else
                            {
                                MessageBox.Show("Пароль должен содержать заглавные и строчные буквы");
                            } // Вывод о безналичии заглавной или строчной буквы.
                        }
                    }
                }
            }   
        }
    }
}

