    class MainThread
    {
        BackgroundLoader bgLoader;
        public MainThread()
        {
            bgLoader = new BackgroundLoader();
        }
        public void LoadItems()
        {
            bgLoader.Load();
        }
    }
    class BackgroundLoader
    {
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        // create the variables to hold the results.
        Map map;
        
        public void Load()
        {
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerAsync();
            while (!backgroundWorker.IsBusy) { }
        }
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // This is where you do the work and load your variables, which you then access once the thread is complete.
            map = LoadMap();
        }
    }
