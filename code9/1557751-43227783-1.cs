    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Dispatcher.Invoke(() => callmyfunction());
                    System.Threading.Thread.Sleep(5000);
                }
            }, TaskCreationOptions.LongRunning);
        }
        public void callmyfunction()
        {
            WindowState = WindowState.Normal;
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
