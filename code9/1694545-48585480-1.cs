    public partial class MainWindow : Window
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (worker.IsBusy)
                worker.CancelAsync();
            else
            {
                cl.Text = String.Empty;
                worker.RunWorkerAsync();
            }
        }
        public ConsoleLog cl { get; set; }
        private BackgroundWorker worker = null;
        public MainWindow()
        {
            InitializeComponent();
            cl = new ConsoleLog();
            DataContext = cl;
            worker = new BackgroundWorker { WorkerSupportsCancellation = true };
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) => cl.addToLog($"{e.Result}");
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Random r = new Random();
            while(true)
            {
                if ((sender as BackgroundWorker).CancellationPending) break;
                cl.addToLog(DateTime.Now.ToString() + Environment.NewLine);
                System.Threading.Thread.Sleep(r.Next(500, 3000));
            }
            e.Result = "Stop" + Environment.NewLine;
        }
    }
