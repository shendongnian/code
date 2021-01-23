    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
       for(int i = 0: i < FolderInfo.Count; i++)
       {
          //... 
          (sender as BackgroundWorker).ReportProgress((int)(100/FolderInfo.Count)*i, null);
       }
    }
    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
    }
