          private void button4_Click(object sender, EventArgs e)
          {
             // Create dialog.
             ProgressWithCancel dlgProgress = new ProgressWithCancel( "Testing progress", LongOperation);
     
             // Show dialog with Synchronous/blocking call.
             // LongOperation() is called by dialog.
             dlgProgress.ShowDialog(); // Synchronous/blocking call.
          }
     
          private void LongOperation(object sender, DoWorkEventArgs e)
          {
             BackgroundWorker worker = sender as BackgroundWorker;
     
             int max = 20;
             for (int i = 0; i < max; i++)
             {
                if (worker.CancellationPending) // See if cacel button was pressed.
                {
                   System.Threading.Thread.Sleep(2000); // Similate time for clean-up.
                   break;
                }
     
                int percent = i * 100 / max;
     
                string userState = percent.ToString(); // render a string to display on the progress dialog.
     
                // Append to string just to show multi-line user-status info.
                if (percent >= 45 && percent <= 55) { userState += "Half way"; }
                if (percent >= 85) { userState += "Almost done"; }
     
                worker.ReportProgress(percent, userState); // Report percent and user-status info to dialog.
     
                System.Threading.Thread.Sleep(800); // Simulate time-consuming operation
             }
          }
     
     
    // Implementation (in ProgressWithCancel.cs)
     
    namespace ProgressWithCancel
    {
       public partial class ProgressWithCancel : Form
       {
          public ProgressWithCancel(string whyWeAreWaiting, DoWorkEventHandler work)
          {
             InitializeComponent();
             this.Text = whyWeAreWaiting; // Show in title bar
             backgroundWorker1.DoWork += work; // Event handler to be called in context of new thread.
          }
     
          private void btnCancel_Click(object sender, EventArgs e)
          {
             label1.Text = "Cancel pending";
             backgroundWorker1.CancelAsync(); // Tell worker to abort.
             btnCancel.Enabled = false;
          }
     
          private void Progress_Load(object sender, EventArgs e)
          {
             backgroundWorker1.RunWorkerAsync();
          }
     
          private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
          {
             progressBar1.Value = e.ProgressPercentage;
             label1.Text = e.UserState as string;
          }
     
          private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
          {
             Close();
          }
     
       }
    }
