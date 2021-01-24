    public partial class MainWindow : Window
    {
        public enum MethodType
        {
            One,
            Two
        }
        private BackgroundWorker worker = null;
        private ProgressBarWindow pbWindowOne = null;
        private ProgressBarWindow pbWindowTwo = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            RunMethodCallers(sender, MethodType.One);
        }
        private void RunMethodCallers(object sender, MethodType type)
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            switch (type)
            {
                case MethodType.One:
                    worker.DoWork += MethodOneCaller;
                    worker.ProgressChanged += worker_ProgressChangedOne;
                    worker.RunWorkerCompleted += worker_RunWorkerCompletedOne;
                    break;
                case MethodType.Two:
                    worker.DoWork += MethodTwoCaller;
                    worker.ProgressChanged += worker_ProgressChangedTwo;
                    worker.RunWorkerCompleted += worker_RunWorkerCompletedTwo;
                    break;
            }
            worker.RunWorkerAsync();
        }
        private void MethodOneCaller(object sender, DoWorkEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                pbWindowOne = new ProgressBarWindow("Running Method One");
                pbWindowOne.Owner = this;
                pbWindowOne.Show();
            });
            Utility.TimeConsumingMethodOne(sender);
        }
        private void MethodTwoCaller(object sender, DoWorkEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                pbWindowTwo = new ProgressBarWindow("Running Method Two");
                pbWindowTwo.Owner = this;
                pbWindowTwo.Show();
            });
            Utility.TimeConsumingMethodTwo(sender);
        }
        private void worker_RunWorkerCompletedOne(object sender, RunWorkerCompletedEventArgs e)
        {
            RunMethodCallers(sender, MethodType.Two);
        }
        private void worker_RunWorkerCompletedTwo(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("COMPLETED!");
        }
        private void worker_ProgressChangedOne(object sender, ProgressChangedEventArgs e)
        {
            pbWindowOne.SetProgressUpdate(e.ProgressPercentage);
        }
        private void worker_ProgressChangedTwo(object sender, ProgressChangedEventArgs e)
        {
            pbWindowTwo.SetProgressUpdate(e.ProgressPercentage);
        }
    }
