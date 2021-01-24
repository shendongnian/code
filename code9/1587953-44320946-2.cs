     public partial class Form1 : Form
     {
       public Form1()
       {
        InitializeComponent();
 
        backgroundWorker1.WorkerReportsProgress = true;
        // This event will be raised on the worker thread when the worker starts
        backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
        // This event will be raised when we call ReportProgress
        backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
       }
      private void button1_Click(object sender, EventArgs e)
      {
        // Start the background worker
        backgroundWorker1.RunWorkerAsync();
      }
    // On worker thread so do our thing!
      void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {
        // Your background task goes here
        for (int i = 0; i <= 100; i++)
        {
            // Report progress to 'UI' thread
            backgroundWorker1.ReportProgress(i);
            // Simulate long task
            if (progressBar1.Value == 25)
            {
                label1.Show();
                label1.Text = "Process Complete 25%";
                System.Threading.Thread.Sleep(200);
            }
           if (progressBar1.Value == 75)
            {
                label1.Show();
                label1.Text = "Process Complete 75%";
                System.Threading.Thread.Sleep(200);
            }
            System.Threading.Thread.Sleep(100);
        }
      }
    // Back on the 'UI' thread so we can update the progress bar
      void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
       {
        // The progress percentage is a property of e
        progressBar1.Value = e.ProgressPercentage;
       }
     }
