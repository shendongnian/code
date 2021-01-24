        BackgroundWorker worker = new BackgroundWorker();
        public MainWindow()
        {
            this.DataContext = viewModel;
            InitializeComponent();
            Server_V2.AsyncService.runMain();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                //availabilityField.Text = Server_V2.AV.ToString();
                viewModel.Availability = Server_V2.AV.ToString();
                Thread.Sleep(500);
            }
        }
