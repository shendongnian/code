    public partial class Form1 : Form
    {    
        IProgress<string> _progress;
        public Form1()
        {
            InitializeComponent();
            _progress = new Progress<string>(UpdateUI);
        }
        void UpdateUI(string message)
        {
            txtResult.Text = message;
        }
        private void btnWorkerThread_Click(object sender, EventArgs e)
        {
            Task.Run(() => SomeLongRunningThread());
        }
        private void SomeLongRunningThread()
        {
            Thread.Sleep(3000);
            _progress.Report(DateTime.Now.ToShortTimeString());
        }
        private void btnUIThread_Click(object sender, EventArgs e)
        {
            SomeLongRunningThread();
        }
    }
