    using System.Diagnostics;
    using System.Windows;
    
    namespace WpfApp1
    {
        public partial class MainWindow 
        {
            public MainWindow()
            {
                InitializeComponent();
    
    
                wb.Navigate("http://google.com");
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Debug.WriteLine(wb.Source.AbsoluteUri);
            }
        }
    }
