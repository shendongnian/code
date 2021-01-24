    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
        }
        struct SOmeData { }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SOmeData data = new SOmeData();
            // backgroundWorker1 result
            e.Result = data;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // backgroundWorker1 result
            SOmeData data = (SOmeData)e.Result;
            // start backgroundWorker2
            backgroundWorker2.RunWorkerAsync(data);
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            // backgroundWorker1 result
            SOmeData data = (SOmeData)e.Argument;
        }
    }
