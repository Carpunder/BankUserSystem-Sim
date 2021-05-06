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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationContext db;
        public static User user;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            user = db.Users.FirstOrDefault(i => i.id == User.userId);
            titleLabel.Content = user?.Login;
            balanceLabel.Content = $"{user.Balance} $";
            if (user.admin == 1)
                adminButton.Visibility = Visibility.Visible;
            var operations = db.Operations.Where(i => i.user_id == user.id).Select(values => new
            {
                values.Type,
                values.Name,
                values.Amount,
                values.date
            }).ToList();
            operationsTable.ItemsSource = operations;

        }

        private void updateTableButton_Click(object sender, RoutedEventArgs e)
        {
            var operations = db.Operations.Where(i => i.user_id == user.id).Select(values => new
            {
                values.Type,
                values.Name,
                values.Amount,
                values.date
            }).ToList();
            operationsTable.ItemsSource = operations;
            balanceLabel.Content = $"{user.Balance} $";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void userInfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Логин: {user.Login}\n" +
                            $"Имя: {user.FirstName}\n" +
                            $"Фамилия: {user.MiddleName}\n" +
                            $"Отчество: {user.LastName}\n" +
                            $"Лицо: {user.Type}\n" +
                            $"Пасспорт: {user.Passport}\n" +
                            $"УНП: {user.Vatin}\n" +
                            $"Телефон: {user.PhoneNumber}\n" +
                            $"Дата Регистрации: {user.registerDate}\n");
        }

        private void replenishmentButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var VARIABLE in Application.Current.Windows)
                if (VARIABLE is ReplenishmentWindow)
                    return;
            ReplenishmentWindow replenishmen = new ReplenishmentWindow { Owner = this };
            replenishmen.Show();
        }

        private void transferButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var VARIABLE in Application.Current.Windows)
                if (VARIABLE is TransferWindow)
                    return;
            TransferWindow transferWindow = new TransferWindow { Owner = this };
            transferWindow.Show();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorization = new AuthorizationWindow();
            authorization.Show();
            Close();
        }

        private void paymentButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var VARIABLE in Application.Current.Windows)
                if (VARIABLE is PaymentWindow)
                    return;
            PaymentWindow paymentWindow = new PaymentWindow { Owner = this };
            paymentWindow.Show();
        }

        private void adminButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
