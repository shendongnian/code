    private void DoWork(object sender, DoWorkEventArgs e)
    {
        var worker = (BackgroundWorker)sender;
        for (int i = 0; i < 100; i++)
        {
            Thread.Sleep(100);
            worker.ReportProgress(i); //This will raise BackgroundWorker.ProgressChanged
        }
    }
