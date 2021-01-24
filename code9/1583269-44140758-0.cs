    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int lol = 100;
            while (lol > 0)
            {
                lol--;
                backgroundWorker1.ReportProgress(100 - lol);
                System.Threading.Thread.Sleep(100);
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            this.Text = e.ProgressPercentage.ToString();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Form Form = new Form1();
            Form.Show();
        }
    }
