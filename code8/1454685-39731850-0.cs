        private BackgroundWorker bw = new BackgroundWorker();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Background Worker code///
            bw.WorkerReportsProgress = true;
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
            //Progress Bar Window
            grdProgress.Visibility = Visibility.Visible;
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //something to do
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Progress Bar Window close
            grdProgress.Visibility = Visibility.Hidden;
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prg.Value = e.ProgressPercentage;
        }
      bw.ReportProgress(value);
