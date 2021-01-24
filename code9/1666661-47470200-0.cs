     delegate void SetLabel(string msg);
     BackgroundWorker worker = new BackgroundWorker();
        private void btn_Start_Click(object sender, EventArgs e)
        {
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
          this.Invoke(new SetLabel(SetLabelMethod), new object[]{     
           "Connecting..."})           
        }
        void SetLabelMethod(string msg)
       { 
         lbl_status.Text = msg;
       }
