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
    /// Логика взаимодействия для PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        public static OperationList OperationsList;
        private ApplicationContext db;

        public PaymentWindow()
        {
            InitializeComponent();
            OperationsList = new OperationList();
            OperationsList.Operations = OperationList.OperationsXmlRead();
            OperationsList.Branches = OperationList.BranchXmlRead();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            typeField.ItemsSource = OperationsList.GetNameList();
        }

        private void typeField_MouseLeave(object sender, MouseEventArgs e)
        {
            
            branchField.ItemsSource = OperationsList.GetBranchList(typeField.Text);
        }

        private void paymentButton_Click(object sender, RoutedEventArgs e)
        {
            if (branchField.Text == null || typeField.Text == null)
                return;
            var temp = 0.0;
            if (!Double.TryParse(numberField.Text, out temp))
            {
                MessageBox.Show("Укажите верную сумму");
                return;
            }
            if (MainWindow.user.Balance < temp)
            {
                MessageBox.Show("Недостаточно денег на балансе");
                return;
            }

            var operation = new Operation(MainWindow.user.id, $"Оплата {typeField.Text} {branchField.Text}", "Оплата", temp);
            MainWindow.user.Balance -= temp;
            db.Operations.Add(operation);
            db.Entry(MainWindow.user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChangesAsync();
            MessageBox.Show("Операция прошла успешно");
            Close();
        }
    }
}
