    private void InitializeBackgroundWorker()
    {
        System.ComponentModel.BackgroundWorker bw = new System.ComponentModel.BackgroundWorker { WorkerReportsProgress = true };
    
    
        bw.DoWork += (sender, e) => e.Result = doSomething();
        bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
        bw.RunWorkerAsync();
    
        bw.RunWorkerCompleted += (sender, e) =>
        {
            AjaxWaitBox.Text = "Completed";
        };
    }
