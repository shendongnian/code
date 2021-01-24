    public Form1()
    {
        InitializeComponent();
        backgroundWorker.WorkerReportsProgress = true;
        backgroundWorker.DoWork += Read;
        backgroundWorker.ProgressChanged += Populate;
        backgroundWorker.RunWorkerCompleted += Finish;
    }
