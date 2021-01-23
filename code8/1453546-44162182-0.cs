    using System;
    using System.Windows;
    using System.Windows.Input;
    
    namespace DialogTouchTest
    {
        /// <summary>
        /// Interaction logic for ConfirmStudentWindow.xaml
        /// </summary>
        public partial class ConfirmStudentWindow : Window
        {
            public Action Confirm;
    
            public ConfirmStudentWindow()
            {
                InitializeComponent();
            }
    
            private void YesButton_Click(object sender, RoutedEventArgs e)
            {
                e.Handled = true;
                Yes();
            }
    
            private void NoButton_Click(object sender, RoutedEventArgs e)
            {
                e.Handled = true;
                No();
            }
    
            private void YesButton_StylusUp(object sender, StylusEventArgs e)
            {
                e.Handled = true;
                Yes();
            }
    
            private void NoButton_StylusUp(object sender, StylusEventArgs e)
            {
                e.Handled = true;
                No();
            }
    
            private void Yes()
            {
                DialogResult = true;
                Confirm();
            }
    
            private void No()
            {
                DialogResult = false;
            }
        }
    }
