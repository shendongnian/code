        BackgroundWorker _BackgroundWorker = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
            _BackgroundWorker.DoWork += _BackgroundWorker_DoWork;
            _BackgroundWorker.RunWorkerCompleted += _BackgroundWorker_RunWorkerCompleted;
            _BackgroundWorker.ProgressChanged += _BackgroundWorker_ProgressChanged;
            _BackgroundWorker.WorkerSupportsCancellation = true;
        }
        void _BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        void _BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
        void _BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            _BackgroundWorker.RunWorkerAsync(e);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _BackgroundWorker.CancelAsync();
        }
