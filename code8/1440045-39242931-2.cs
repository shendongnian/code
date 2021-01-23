    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private BackgroundWorker worker;
        private void btnStartWorker_Click(object sender, EventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //long running operation here
            Thread.Sleep(5000);
        }
        private void btnOther_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Doing other stuff");
        }
    }
