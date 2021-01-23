    public ViewModel()
        {
            ...
    
            backgroundWorker.ReportsProgress = true;
            backgroundWorker.ProgressChanged += OnProgressChanged;
    
            ...
        }
    private void DoWork(object sender, DoWorkEventArgs e)
    {
        isUpdating = true;
        ...
        ReportProgress(0,"BackgroundWorker is running...");
        for (...)
        {
            ...
            if(...)
            {
                ReportProgress(0,"value1");
            }
            else
            {
                ReportProgress(0,"value2");
                ...
            }     
        }
    }
