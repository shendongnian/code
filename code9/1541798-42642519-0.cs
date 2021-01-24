    private void Main(string[] args)
    {
        BackgroundWorker bw = new BackgroundWorker();
        bw.DoWork += Bw_DoWork;
        bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
        
        //Parameter you need to work in Background-Thread for example your strings
        string[] param = new[] {"Text1", "Text2", "Text3", "Text4"};
        
        //Start work
        bw.RunWorkerAsync(param);
    }
    //Do your Background-Work
    private void Bw_DoWork(object sender, DoWorkEventArgs e)
    {
        string[] param = e.Argument as string[];
    
        //Process your long running  task
    
        e.Result = null; //Set your Result of the long running task
    }
    //Taking your results
    private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        //Apply your Results to your GUI-Elements
        myTextBox1.Text = e.Result.ToString();
    }
