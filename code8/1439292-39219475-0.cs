    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // do calculation ...
        e.Result = resultString;      
    }
    
    private void backgroundWorker_RunWorkerCompleted(object sender, DoWorkEventArgs e)
    {
        // check cancellation ...
        webBrowser1.DocumentText = e.Result;
    }
