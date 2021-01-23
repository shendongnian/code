     private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                for (int i = 0; i <= 100; i++ )
                {
                    simulateHeavyWork();
                    backgroundWorker1.ReportProgress(i);
                }
            }
            private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                csvprogressbar.Value = e.ProgressPercentage;
            }
            private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                writecsv(null, null);
            }
            private void simulateHeavyWork() 
            {
                Thread.Sleep(40);
            }
