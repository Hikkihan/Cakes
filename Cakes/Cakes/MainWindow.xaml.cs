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
using System.Data.Entity;

namespace Cakes
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

        private void Войти_Click(object sender, RoutedEventArgs e)
        {
            string loginUser = LoginBox.Text;    //Подключение к базе данных
            string passUser  = PassBox.Password;       //Подключение к базе данных

            CakesEntities db = new CakesEntities();
            db.Пользователи.Load(); //Подключение к базе данных
            var user = db.Пользователи
                .Where(u => u.Login == loginUser && u.Password == passUser)
                .FirstOrDefault();
            //Сравнение логина и пароля 

            if (user == null)
            {
                MessageBox.Show("Логин или пароль введены неверно!");
            } //Проверка ввода логина и пароля

            if (user != null)
            {
                if (user != null && user.Role == "Заказчик")
                {
                    User_cabinet user_cabinet = new User_cabinet();
                    user_cabinet.Show();
                    Close();

                } //Проверка роли пользователя

                if (user != null && user.Role == "Менеджер по продажам")
                {
                    ManagerClient_cabinet managerClient_cabinet = new ManagerClient_cabinet();
                    managerClient_cabinet.Show();

                    Close();

                }//Проверка роли менеджера по продажам
                if (user != null && user.Role == "Менеджер по закупкам")
                {
                    Manager_Buyer manager_Buyer_cabinet = new Manager_Buyer();
                    manager_Buyer_cabinet.Show();
                    Close();

                } //Проверка Менеджера по закупам
                if (user != null && user.Role == "Мастер")
                {
                    Master_cabinet master_cabinet = new Master_cabinet();
                    master_cabinet.Show();

                    Close();

                }//Проверка роли Мастера
                if (user != null && user.Role == "Директор")
                {
                    Director_cabinet director_cabinet = new Director_cabinet();
                    director_cabinet.Show();

                    Close();
                }//Проверка роли Директора

            }  //Проверка на наличие пользователя в бд.

        }
    

        private void Регистрация_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPage registration_page = new RegistrationPage();
            registration_page.Show();
        }
    }
}
