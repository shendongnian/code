    private static void Worker_DoWork(object sender, DoWorkEventArgs e)
            {
                int size = 100;
    
                // Function to Setup your Progressbar
                form.SetUpProgressBar(size);
    
                // hard work...
                for (int i = 0; i < size; i++)
                {
                    Thread.Sleep(100);
    
                    // Fires the Worker_ProgressChanged Event with the Percentage of the current progress
                    (sender as BackgroundWorker).ReportProgress(i + 1);
                }
            }
    
            private static void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                // Update the ProgressBar
                form.progressBar1.Value = e.ProgressPercentage;
            }
    
            private static void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                MessageBox.Show("Hey I'm done!");
            }
