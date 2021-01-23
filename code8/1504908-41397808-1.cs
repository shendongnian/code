    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        if (backgroundWorker1.CancellationPending == true)
        {
            e.Cancel = true;
            return; // this will fall to the finally and close everything    
        }
        else
        {
            ExtractImages ei = new ExtractImages();
            ei.ProgressChanged += (sender, e) => backgroundWorker1.ReportProgress(e.Percentage, e);
            ei.Init();
        }
    }
