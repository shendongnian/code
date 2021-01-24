    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task.Run(()=> 
            {
                while (true)
                {
                    Dispatcher.Invoke(()=> callmyfunction());
                    System.Threading.Thread.Sleep(5000);
                }
            });
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
