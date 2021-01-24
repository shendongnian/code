    private void Worker_DoWork(object sender, DoWorkEventArgs e)
    {
        for (int i = 0; i < directories.Count; i++)
        {
            BitmapImage imagetosave = ResizeImage(directories[i]);
            Save(imagetosave, saveDirectory);
            int x = i + 1;
            int percents = (x * 100) / directories.Count;
            worker.ReportProgress(percents, x);
        }
    }
