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
    /// Логика взаимодействия для ReplenishmentWindow.xaml
    /// </summary>
    public partial class ReplenishmentWindow : Window
    {
        private ApplicationContext db;
        public ReplenishmentWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Operation operation;
            var temp = 0.00;
            if (Double.TryParse(amountField.Text, out temp) && temp > 0)
            {
                operation = new Operation(User.userId, "Пополнение баланса", "Пополнение", temp);
                db.Operations.Add(operation);
                MainWindow.user.Balance += temp;
                db.Entry(MainWindow.user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChangesAsync();
                MessageBox.Show("Операция прошла успешно");
                Close();
            }
            else
            {
                MessageBox.Show("Введите сумму в правильном формате!");
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
