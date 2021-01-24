    private void Worker_DoWork(object sender, DoWorkEventArgs e)
    {
        for (int i = 0; i < directories.Count; i++)
        {
            ...
            int x = i + 1;
            worker.ReportProgress(percents, directories.Count - x);
        }
    }
