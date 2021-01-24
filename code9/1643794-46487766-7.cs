    System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
    void StartBackgroundTask()
    {
        worker.DoWork += worker_DoWork;
        //if it's possible to display progress, use this
        worker.WorkerReportsProgress = true;
        worker.ProgressChanged += worker_ProgressChanged;
        //what to do when the method finishes?
        worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        //start!
        worker.RunWorkerAsync();
    }
    void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
        //perform any "finalization" operations, like re-enable disabled buttons
        //display the result using the data in e.Result
        //this code will be running in the UI thread
    }
    //example of a container class to pass more data in the ReportProgress event
    public class ProgressData
    {
        public string OperationDescription { get; set; }
        public int CurrentResult { get; set; }
        //feel free to add more stuff here
    }
    void worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        //display the progress using e.ProgressPercentage or e.UserState
        //this code will be running in the UI thread
        //UserState can be ANYTHING:
        //var data = (ProgressData)e.UserState;
    }
    void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        //this code will NOT be running in the UI thread!
        //you should NOT call the UI thread from this method
        int result = 1;
        //perform calculations
        for (var i = 1; i <= 10; i++)
        {
            worker.ReportProgress(i, new ProgressData(){ OperationDescription = "CustomState passed as second, optional parameter", CurrentResult = result });
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            result *= i;
        }
        e.Result = result;
    }
