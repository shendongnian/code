    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnGoClick(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += OnDoWork;
            worker.RunWorkerCompleted += OnRunWorkerCompleted;
            progressRing.IsActive = true;
            progressRing.Visibility = Visibility.Visible;
            worker.RunWorkerAsync();
        }
        private void OnDoWork(object o, DoWorkEventArgs args)
        {
            Task.Delay(2000).Wait(); // Pretend to work
        }
        private void OnRunWorkerCompleted(object o, RunWorkerCompletedEventArgs args)
        {
            progressRing.Visibility = Visibility.Collapsed;
            progressRing.IsActive = false;
        }
    }
