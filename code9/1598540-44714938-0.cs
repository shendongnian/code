    BackgroundWorker worker = new BackgroundWorker();
    worker.DoWork += bgwTA_DoWork;
    worker.RunWorkerCompleted += bgwTA_RunWorkerCompleted;
    worker.RunWorkerAsync();
    
    private void bgwTA_DoWork(object sender, DoWorkEventArgs e)
    {
        dtTopSQL.Clear();
        odaTopSQL = new OracleDataAdapter(getTopSQLDetails, oradb);
        odaTopSQL.Fill(dtTopSQL);
        //etc
    
    	e.Result = dt1;
    }
    
    private void bgwTA_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
       {
        if (e.Cancelled)
        {
    		//Process was cancelled, need to clean up here
        }
        else if (e.Error != null)
        {
    		//Here was an error running the process. or the thread aborted.  
    		//Need to raise errors and clean up here
    		//If your process threw an exception, then it will be here                
        }
        else
        {
            //Everything worked OK, now we can update our UI elements
            //The Worker Completed thread will come back to the thread which called it.  Which, means if called from you main UI thread that you don't have to use invoke
    		
    		ugTopSQL.DataSource = (DataTable)e.Result;
    	}
    }
