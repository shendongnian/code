    private BackgroundWorker worker;
     public MainWindow()
     {
        InitializeComponent();
        this.worker = new BackgroundWorker();
        this.worker.DoWork += new DoWorkEventHandler(myWorker_DoWork);
        this.worker.RunWorkerCompleted += new 
        RunWorkerCompletedEventHandler(myWorker_RunWorkerCompleted);
        this.worker.ProgressChanged += new 
        ProgressChangedEventHandler(myWorker_ProgressChanged);
        this.worker.WorkerReportsProgress = true;
        this.worker.WorkerSupportsCancellation = true;
    }
    private void myWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        this.progressBar.Value = e.ProgressPercentage;
    }
    private void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
         // Whatever you need to do when finished here (alert, update a label, etc.)
    }
    private void myWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // Just loop and report new progress. Sleep a little in between each
        // progress update so that it isn't over before we have a chance to see it.
        for(int i=0;i<100;i++)
        {
            Thread.Sleep(200);
            this.worker.ReportProgress(i);
        }
    }
    private void btnStart_Click(object sender, RoutedEventArgs e)
    {
        this.worker.RunWorkerAsync();
    }
