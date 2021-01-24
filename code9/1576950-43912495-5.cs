     public partial class Form1 : Form
        {
            private BackgroundWorker _backgroundfWorker;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                _backgroundfWorker = new BackgroundWorker();
                _backgroundfWorker.ProgressChanged += OnUpdateStatus;
                _backgroundfWorker.DoWork += backgroundWorker1_DoWork;
                _backgroundfWorker.WorkerReportsProgress = true;
                _backgroundfWorker.RunWorkerAsync();
            }
    
            private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
            {
                var b = new ProjectB();
                b.OnUpdateStatus += ProjectBOnUpdateStatus;
                b.Run();
            }
    
            private void ProjectBOnUpdateStatus(string message)
            {
                _backgroundfWorker.ReportProgress(0, message);
            }
        
            private void OnUpdateStatus(object sender,ProgressChangedEventArgs progressChangedEventArgs)
            {
                MessageBox.Show(progressChangedEventArgs.UserState.ToString());
            }
        }
