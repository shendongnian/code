    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        int lol = 100;        
        while (lol > 0)
        {
            // report
            backgroundWorker1.ReportProgress(100-lol);
            lol--;
            System.Threading.Thread.Sleep(100);
        }
    }
