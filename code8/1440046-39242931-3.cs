    public partial class Form1 : Form
    {
        private delegate void ReenableDelegate();
        public Form1()
        {
            InitializeComponent();
        }
        private BackgroundWorker worker;
        private void btnStartWorker_Click(object sender, EventArgs e)
        {
            btnStartWorker.Enabled = false;
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            Thread.Sleep(5000); // simulate long running operation here
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new ReenableDelegate(Enable));
        }
        private void Enable()
        {
            btnStartWorker.Enabled = true;
        }
        private void btnOther_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Doing other stuff");
        }
    }
