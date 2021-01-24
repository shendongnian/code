    using System.Windows;
    
    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            Window winA = new Window();
            Window winB = new Window();
            Window winC = new Window();
    
            public MainWindow()
            {
                InitializeComponent();
    
                winA.Title = "A";    
                winB.Title = "B";
                winC.Title = "C";
    
                winB.Show();
                winA.Show();
                winC.Show();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                winB.ShowInTaskbar = false;
                winA.ShowInTaskbar = false;
                winC.ShowInTaskbar = false;
    
                winA.ShowInTaskbar = true;
                winB.ShowInTaskbar = true;
                winC.ShowInTaskbar = true;
    
            }
        }
    }
