    //Create new object and start processing
    MySite.Data.ProcessData Batch = new Data.ProcessData();
    Batch.StartBatchProcessing();
    
    //The StartBatchProcessing() Creates the new thread
    public void StartBatchProcessing()
    {    
        //ProcessMyData is the main method that will process the batch data
        Thread newThread = new Thread(this.ProcessMyData); //another thread
        newThread.Priority = ThreadPriority.Normal;
        newThread.Start();
    }
