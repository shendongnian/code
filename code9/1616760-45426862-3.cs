    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Model.GetInstance();
            StaticTimerManager.Initialize();
        }
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                StaticTimerManager.StartTimer();
            });
        }
        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            StaticTimerManager.StopTimer();
        }
    }
