    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += new DoWorkEventHandler(DoWork);
        worker.WorkerReportsProgress = false;
        worker.WorkerSupportsCancellation = true;
        worker.RunWorkerCompleted +=
               new RunWorkerCompletedEventHandler(WorkerCompleted);
 
        //Add this BackgroundWorker object instance to the cache (custom cache implementation)
        //so it can be cleared when the Application_End event fires.
        CacheManager.Add("BackgroundWorker", worker);
       
        // Calling the DoWork Method Asynchronously
        worker.RunWorkerAsync(); //we can also pass parameters to the async method....
       
    }
 
    private static void DoWork(object sender, DoWorkEventArgs e)
    {
       
        // You code to send mail..
    }
   
    private static void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        if (worker != null)
        {
            // sleep for 30 minutes and again call DoWork to send mail.
            System.Threading.Thread.Sleep(3600000);
            worker.RunWorkerAsync();
        }
    }
 
    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
        //If background worker process is running then clean up that object.
        if (CacheManager.IsExists("BackgroundWorker"))
        {
            BackgroundWorker worker = (BackgroundWorker)CacheManager.Get("BackgroundWorker");
            if (worker != null)
                worker.CancelAsync();
        }
    }
