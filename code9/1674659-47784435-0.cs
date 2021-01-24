    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            grid1.Rows.Clear();
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (string name in studentRoster)
            {
                InsertIntoDB();
                
                // You can report progress by calling the following function.
                //backgroundWorker1.ReportProgress(int percentProgress, object userState)
                // You can set the percentProgress to any valid integer value,
                // and userState can be any object you want.
                // You can also check to see if this operation has been sent a request to cancel.
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
            // You can send information back to the main thread by setting e.Result to any object you want.
        }
        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Do something with the event that is being raised.
            // To pass a value back through to this event, use the percentProgress and userState
            // parameters of the ReportProgress function.
            // the userState object that you pass will be received here as e.UserState
        }
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // This event is raised by the background worker when the DoWork method is completed.
            // You can receive information back from the worker thread by evaluating e.Result
        }
    }
}
