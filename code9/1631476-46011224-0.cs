    BackgroundWorker worker;
    public void Init()
    {
        worker = new BackgroundWorker();
        worker.DoWork += Worker_DoWork;
        worker.ProgressChanged += Worker_ProgressChanged;
        worker.WorkerReportsProgress = true; // This is important
        worker.RunWorkerAsync();
    }
    
    private void Worker_DoWork(object sender, DoWorkEventArgs e)
    {
        // Do your update progress here...
        
        for (int i = 0; i <= 100; i++) // This simulates the update process
        {
            System.Threading.Thread.Sleep(100);
            worker.ReportProgress(i); // Report progress from the background worker like this
        }
    }
    private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // Update the progress bar or other ui elements here...
        // Use the e.ProgressPercentage
    }
