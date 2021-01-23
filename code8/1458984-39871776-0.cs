     public void updateProgress(int percentage, string currentWork)
        {
            label_processInfo.Text = percentage + " - " + currentWork;
            backgroundWorker.ReportProgress(percentage,"New Label Value");
        }
     private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            string newLabelValue = (String)e.UserState;
        }
