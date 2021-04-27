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

namespace KursRSPO
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void RegistrationRoot_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void numberField_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (numberField.Text == "")
            {
                numberField.Text = "+375";
            }
        }

        private void numberField_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (numberField.Text == "+375")
            {
                numberField.Text = "";
            }
        }
    }
}
