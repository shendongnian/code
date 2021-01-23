    using System.Windows;
    namespace Player
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                ViewModel = new MainViewModel();
                ViewModel.Player = new PlayerViewModel() { Name = "Ivan the Terrible" };
            }
            //  Just here as a convenience, and to make sure we don't give the DataContext
            //  the wrong kind of viewmodel. 
            public MainViewModel ViewModel
            {
                set { DataContext = value; }
                get { return DataContext as MainViewModel; }
            }
            private void Greeting_Click(object sender, RoutedEventArgs e)
            {
                ViewModel.AddGreeting();
            }
        }
    }
