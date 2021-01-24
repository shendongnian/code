    public Form1()
    {
        tbxResult.Text = "Assign text Ok";
        bw.DoWork += backgroundWorker_DoWork;
        bw.WorkerReportsProgress = true;
        bw.ProgressChanged += (sender, e) => tbxResult.Text = (string)e.UserState;
        bw.RunWorkerAsync();
    }
    void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        var status = "assign some value";
        bw.ReportProgress(0, status);
    }
