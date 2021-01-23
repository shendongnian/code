    BackgroundWorker bkw = new BackgroundWorker();
    bkw.WorkerReportsProgress = true;
    bkw.WorkerSupportsCancellation = true;
    bkw.ProgressChanged += bgw_ProgressChanged;
    bkw.DoWork += bgw_DoWork;
    bkw.RunWorkerAsync();
    ...
    private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        WorkerItem item = e.UserState as WorkerItem;
        ... update a progress bar, show the current item in a label etc...
        Console.WriteLine($"Completed: {e.ProgressPercentage}% {WorkerItem.Counter} {WorkerItem.Item}");
    }
