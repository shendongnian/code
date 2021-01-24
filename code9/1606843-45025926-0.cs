    private void elapsed_time(object sender, Eventargs e)
    {
         System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
         worker.DoWork += NewBackgroundWork_Start;
         worker.RunWorkerCompleted += NewWork_Completed;
         worker.RunWorkerAsync();
    }
    
    private void NewBackgroundWork_Start(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
         Console.Writeline("I am the new job");
    }
    private void NewWork_Completed(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
         Console.Writeline("The job is complete");
    }
