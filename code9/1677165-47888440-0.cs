     private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }
    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // get your result-object and cast it to the desired type
        string myStringResult = (string)e.Result;
        // and here we are back in the UI-Thread
    }
    private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // Now we are in the UI-Thread
        // get the passed progress-object and cast it to your desired type
        string myStringObject = (string)e.UserState;
        // do some UI-Stuff...
    }
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // get your argument 
        string input = (string)e.Argument;
        // do your async stuff
        // to call the progress-changed handler call
        ((BackgroundWorker)sender).ReportProgress(0, null /*Object to pass to the progress-changed method*/);
        // to pass an object to the completed-handler call
        e.Result = null; // null = your object
    }
    private void btnUitvoeren_Click(object sender, EventArgs e)
    {
        backgroundWorker.RunWorkerAsync(txtBoxInput.Text);  // pass the input-string to the do-work method
        lblStatus.Text = "Process is bezig... een moment geduld aub";
    }
