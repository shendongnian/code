                private void This_is_Your_Button_Click_EVENT(object sender, EventArgs e)
                {
                        BackgroundWorker worker = new BackgroundWorker();
                        worker.WorkerReportsProgress = true;
                        worker.DoWork += worker_DoWork;
                        worker.ProgressChanged += worker_ProgressChanged;
                        worker.RunWorkerAsync();
                }
                void worker_DoWork(object sender, DoWorkEventArgs e)
                {
                        for(int i = 0; i < 100; i++)
                        {
                                (sender as BackgroundWorker).ReportProgress(i);
                                Thread.Sleep(100);
                        }
                }
                void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
                {
                        pbStatus.Value = e.ProgressPercentage;
                }
