    private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
        { 
            // Check for errors...
        }
        else if (e.Cancelled)
        {
             // Mark that this one has finished
        }
        else
        {
             // Assuming you have a set of BackgroundWorkers called "workers"
             foreach (var bgw in workers)
                 bgw.CancelAsync();
             // other stuff...
        }
    }
