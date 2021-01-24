    public partial class MainWindow : Window
    {
        TimerManager _timerManager = new TimerManager();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Model.GetInstance();
        }
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                _timerManager.StartTimer();
            });
        }
        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            _timerManager.StopTimer();
        }
    }
