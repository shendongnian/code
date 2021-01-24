    private void button1_Click(object sender, EventArgs e)
    {
        // on and off
        if (backgroundWorker1.IsBusy)
        {
            // cancel if we have not already done so
            if (!backgroundWorker1.CancellationPending)
            {
                backgroundWorker1.CancelAsync();
            }
        }
        else
        {
            // start the background work
            button1.BackColor = Color.Yellow;
            backgroundWorker1.RunWorkerAsync();
        }
    }
    // this runs on a background thread
    // do not do stuff with the UI here
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        int progress = 0;
        // stop looping if cancellation is requested
        while (!backgroundWorker1.CancellationPending)
        {
            // make it nice
            backgroundWorker1.ReportProgress(progress);
            ClearScreenLogic.Run();
            if (AutoReconnect)
                ReconnectLogic.Run();
            // Etc..
            progress++; // for feedback
        }
    }
    // tell the use something is going on, this runs on the UI thread
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        label1.Text = e.ProgressPercentage.ToString();
    }
 
    // we're done, tell the user so
    // this runs on the UI thread 
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        button1.BackColor = Color.Green;
        label1.Text = "cancelled";
    }
