        BackgroundWorker bg;
        ....
        // Constructor: create the worker (once):
         bg = new BackgroundWorker();
         bg.WorkerSupportsCancellation = true;
         bg.DoWork += new DoWorkEventHandler(bg_DoWork);
         bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
        private void btnStartBgw_Click(object sender, EventArgs e)
        {
            if (!bg.IsBusy)
                bg.RunWorkerAsync();
            else MessageBox.Show("The worker thread is busy!");
        }
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            this.DoWorkImpl((BackgroundWorker)sender, e);
        }
        private void DoWorkImpl(BackgroundWorker backgroundWorker, DoWorkEventArgs e)
        {
            for(int i=0;i<30;i++)
            {
                Thread.Sleep(1000);
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The work was canceled");
            }
            else
            {
                MessageBox.Show("The work was completed successfuly");
            }
        }
        private void btnCancelBgw_Click(object sender, EventArgs e)
        {
            if (bg.IsBusy) bg.CancelAsync();
            else MessageBox.Show("The worker thread is not running!");
        }
