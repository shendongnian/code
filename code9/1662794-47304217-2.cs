    private  void Porcessing_Click(object sender, EventArgs e)
    {
        var worker = new BackgroudWorker(); 
        label1.Text = "start under process..";
        worker.DoWork+=BackgroudAction;
        worker.RunWorkerCompleted+=BackgroudActionEnd;
        worker.RunWorkerAsync();
    }
    private void BackgroudAction(object sender, DoWorkEventArgs e)
    {
        Thread.Sleep(5000);
    }
    private void BackgroudActionEnd( object sender,RunWorkerCompletedEventArgs e)
    {
        label1.Text="Result";
    }
    
