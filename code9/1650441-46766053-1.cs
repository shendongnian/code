    private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
       int count = 0;
       BackgroundWorker worker = sender as BackgroundWorker;
            while (!exit)
            {
                DateTime Time1 = DateTime.Now;
                worker.ReportProgress(count);
                count++;
                if (count > 1000)
                {
                    exit = true;
                }
                Thread.Sleep(10);
            }
    }
    
    // This event handler updates the progress.
            private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                resultLabel.Text = ("Background thread count = " + e.ProgressPercentage.ToString());
            }
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                resultLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                resultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                resultLabel.Text = "Done!";
            }
        }
