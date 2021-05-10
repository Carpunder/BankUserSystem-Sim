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
    /// Логика взаимодействия для AdminPaymentsWindow.xaml
    /// </summary>
    public partial class AdminPaymentsWindow : Window
    {
        private OperationList operationList;
        public AdminPaymentsWindow()
        {
            InitializeComponent();
            operationList = new OperationList();
            operationList.Operations = OperationList.OperationsXmlRead();
            operationList.Branches = OperationList.BranchXmlRead();
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
            operationsTable.ItemsSource = operationList.Operations.Select(i => new
            {
                i.id,
                i.Name
            }).ToList();

            branchTable.ItemsSource = operationList.Branches.Select(i => new
            {
                i.parent,
                i.branch
            }).ToList();

        }
    }
}
