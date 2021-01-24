    public class TestObject : INotifyPropertyChanged {
        private BackgroundWorker worker;
        public TestObject() {
            worker = new BackgroundWorker() {
                WorkerReportsProgress = true
            };
            worker.DoWork += DoWork;
            worker.ProgressChanged += WorkProgress;
            worker.RunWorkerCompleted += WorkFinished;
        }
        public int Progress
        {
          get { return _progress; }
          set { _progress = value; RaisePropertyChanged("Progress"); }
        }
        // Begin doing work
        public void TestWork() {
            worker.RunWorkerAsync();
        }
        private void DoWork(object sender, DoWorkEventArgs eventArgs) {
            worker.ReportProgress(0, "Work started");
            
            for (int i = 0; i < 100; i++) {
                System.Threading.Thread.Sleep(10);
                worker.ReportProgress(i, "Message");
            }
        }
        // Fires when the progress of a job changes.
        private void WorkProgress(object sender, ProgressChangedEventArgs e) {
            // Do something with the progress here
            Progress = e.ProgressPercentage;
        }
        // Fires when a job finishes.
        private void WorkFinished(object sender, RunWorkerCompletedEventArgs e) {
            // The work finished. Do something?
        }
   
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
          // NOTE: If you're running C#6 use the null conditional operator for this check.
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e));
        }
    }
