                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                bw.WorkerReportsProgress = true;
                bw.RunWorkerAsync();
                pbar.Maximum = 100;
                pbar.Minimum = 0;
                pbar.Value = 0;
                // Percentage will be added to the end of this line during the upgrade
                updateMsg.Content = "Upgrade in progress...     ";
            }
        }
      
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            updater.updater(bw);
        }
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        { 
            pbar.Value = e.ProgressPercentage;
            updateMsg.Content = String.Format("Upgrade in progress...  {0} %", e.ProgressPercentage);
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            updateMsg.Content = "Upgrade Complete. Exit window to proceed...";
        }
