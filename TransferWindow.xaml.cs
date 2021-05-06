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
    /// Логика взаимодействия для TransferWindow.xaml
    /// </summary>
    public partial class TransferWindow : Window
    {
        private ApplicationContext db;
        public TransferWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void transferButton_Click(object sender, RoutedEventArgs e)
        {
            User transferUser = db.Users.FirstOrDefault(i => i.Login == loginField.Text);
            var temp = 0.0;
            if (!Double.TryParse(amountField.Text, out temp))
            {
                MessageBox.Show("Укажите верную сумму");
                return;
            }
            if (MainWindow.user.Balance < temp)
            {
                MessageBox.Show("Недостаточно денег на балансе");
                return;
            }
            if (transferUser != null)
            {
                var operationFrom = new Operation(MainWindow.user.id, $"Перевод клиенту {loginField.Text}", "Перевод", temp);
                var operationTo = new Operation(transferUser.id, $"Перевод от {MainWindow.user.Login}", "Пополнение", temp);
                transferUser.Balance += temp;
                MainWindow.user.Balance -= temp;
                db.Operations.Add(operationFrom);
                db.Operations.Add(operationTo);
                db.Entry(MainWindow.user).State = System.Data.Entity.EntityState.Modified;
                db.Entry(transferUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChangesAsync();
                MessageBox.Show("Операция прошла успешно");
                Close();
            }
            else
            {
                MessageBox.Show("Такого клиента не существует");
            }
        }
    }
}
