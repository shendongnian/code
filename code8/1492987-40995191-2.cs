    namespace PostponeRadioButtonChange
    {
        using System;
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Input;
    
        using VM = PostponeRadioButtonChange.Model;
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new VM.MainWindow();
            }
    
            private void RadioButtonMouseDown(object sender, MouseButtonEventArgs e)
            {
                var rb = (sender as RadioButton);
    
                if (rb == null)
                    throw new InvalidCastException("RadioButtonMouseDown only for RadioButton's");
    
                e.Handled = (rb.Tag as Func<bool>)?.Invoke() ?? false;
            }
        }
    }
