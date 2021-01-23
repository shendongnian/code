    public ActionResult MyAction(object param)
    {
        ExecuteBackgroundWorker(param); // your model containing the method you want to execute
        return View(); // This will return the view while the background worker proceeds.
    }
    
    public void ExecuteBackgroundWorker(object param)
    {
        BackgroundWorker bgWorker = new BackgroundWorker();
        bgWorker.DoWork += bgWorker_DoWork;
        bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
        bgWorker.RunWorkerAsync(param);
    }
    
    void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // Do Something when work ends
    }
    
    void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        var OPsModel = (MyModel)e.Argument; // Cast object back to original model
        OPsModel.ExecuteProcess(); // Execute the process
    }
