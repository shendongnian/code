    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Shift && 
            e.KeyCode == Keys.Delete)
        {
            if (backgroundWorker1.IsBusy)
            {
                Trace.WriteLine("cancelling");
                backgroundWorker1.CancelAsync();
            }
            textBox.Clear();
        }
               
        if (e.Shift && 
            e.KeyCode == Keys.ShiftKey && 
            !backgroundWorker1.IsBusy)
        {
            backgroundWorker1.RunWorkerAsync();
        }
               
    }
    
    private void  backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        e.Result = false;
        // wait 2 seconds (that is a bit long, adjust accordingly)
        Thread.Sleep(2000); // HACK, use a proper timer here
        // tell RunWorkerCompleted if we're good to clear
        e.Result = !backgroundWorker1.CancellationPending;
    }
    
    // this gets called on the UI thread
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Trace.WriteLine(String.Format("{0} - {1}", e.Cancelled, e.Result));
        if ((bool) e.Result)
        {
            listBox.Items.Clear();
        }
    }
