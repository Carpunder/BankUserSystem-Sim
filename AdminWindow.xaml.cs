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
using KursRSPO.Classes;

namespace KursRSPO
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private ApplicationContext db;
        public AdminWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            usersTable.IsReadOnly = true;
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            titleLabel.Content = MainWindow.user.Login;
            usersTable.ItemsSource = db.Users.Select(values => new
            {
                values.id,
                values.Type,
                values.Login,
                values.Balance,
                values.Vatin,
                values.PhoneNumber,
                values.FirstName,
                values.MiddleName,
                values.LastName,
                values.registerDate,
                values.admin
            }).ToList();
            operationsTable.ItemsSource = db.Operations.Select(values => new
            {
                values.Type,
                values.Name,
                values.Amount,
                values.Date
            }).ToList(); ;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void updateUsersTableButton_Click(object sender, RoutedEventArgs e)
        {
            usersTable.ItemsSource = db.Users.Select(values => new
            {
                values.id,
                values.Type,
                values.Login,
                values.Balance,
                values.Vatin,
                values.PhoneNumber,
                values.FirstName,
                values.MiddleName,
                values.LastName,
                values.registerDate,
                values.admin
            }).ToList();
        }

        private void updateOperationsTableButton_Click(object sender, RoutedEventArgs e)
        {
            var userId = 0;
            if (Int32.TryParse(userIdField.Text, out userId) && db.Operations.FirstOrDefault(i => i.user_id == userId) != null)
            {
                operationsTable.ItemsSource = db.Operations.Where(i => i.user_id == userId).Select(values => new
                {
                    values.Type,
                    values.Name,
                    values.Amount,
                    values.Date
                }).ToList();
            }
            else
            {
                MessageBox.Show("Пользователя с таким Id нету!");
            }
        }

        private void makeAdminButton_Click(object sender, RoutedEventArgs e)
        {
            var user_id = Convert.ToInt32(userAdminIdField.Text);
            var user = db.Users.FirstOrDefault(i => i.id == user_id);
            if (user != null)
            {
                user.admin = 1;
                db.SaveChangesAsync();
                MessageBox.Show($"Пользователь {user.Login} получил права адниминстратора!");
            }
            else
            {
                MessageBox.Show("Пользователя с таким Id нету!");
            }
        }

        private void allOperationButton_Click(object sender, RoutedEventArgs e)
        {
            operationsTable.ItemsSource = db.Operations.Select(values => new
            {
                values.Type,
                values.Name,
                values.Amount,
                values.Date
            }).ToList();
        }

        private void unAdminButton_Click(object sender, RoutedEventArgs e)
        {
            var user_id = Convert.ToInt32(userAdminIdField.Text);
            var user = db.Users.FirstOrDefault(i => i.id == user_id);
            if (user != null)
            {
                if (user.id == MainWindow.user.id)
                {
                    MessageBox.Show("Нельзя снять самого себя");
                    return;
                }
                if (user.Login == "admin")
                {
                    MessageBox.Show("Нельзя снять главного админа");
                    return;
                }

                user.admin = 0;
                db.SaveChangesAsync();
                MessageBox.Show($"Пользователь {user.Login} лишился прав адниминстратора!");
            }
            else
            {
                MessageBox.Show("Пользователя с таким Id нету!");
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var userId = Convert.ToInt32(userAdminIdField.Text);
            var user = db.Users.FirstOrDefault(i => i.id == userId);
            if (user != null)
            {
                if (user.admin == 1)
                {
                    MessageBox.Show("Нельзя удалить админа");
                    return;
                }

                foreach (var VARIABLE in db.Operations.Where(i => i.user_id == userId))
                {
                    db.Operations.Remove(VARIABLE);
                }
                db.Users.Remove(user);
                db.SaveChangesAsync();
                MessageBox.Show($"Пользователь {user.Login} удален!");
            }
            else
            {
                MessageBox.Show("Пользователя с таким Id нету!");
            }
        }

        private void paymentButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var VARIABLE in Application.Current.Windows)
                if (VARIABLE is AdminPaymentsWindow)
                    return;
            AdminPaymentsWindow adminPayments = new AdminPaymentsWindow { Owner = this };
            adminPayments.Show();
        }
    }
}
