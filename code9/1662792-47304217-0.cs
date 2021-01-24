    var worker = new BackgroudWorker(); 
    worker.DoWork+=BackgroudAction;
    worker.RunWorkerCompleted+=BackgroudActionEnd;
    worker.RunWorkerAsync();
    private void BackgroudAction(object sender, DoWorkEventArgs e)
    {
    Thread.Sleep(5000);
    }
    private void BackgroudActionEnd( object sender,RunWorkerCompletedEventArgs e)
    {
    label1.Text="Result";
    }
    
