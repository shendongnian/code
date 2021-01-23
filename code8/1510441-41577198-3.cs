      public partial class Form1 : Form
      {
        BackgroundWorker worker;
    
        public Form1()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_Completed;
        }
         
        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (outLine.Data != null)
            {
                if (!worker.IsBusy) //Check if Worker is working and avoid exception
                   worker.RunWorkerAsync();     
            }
        }
    
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Process some Long-Running Task
            Thread.Sleep(5000)
            e.Result = "Done!";
        }
    
        private void worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
           textbox.Text = e.Result.ToString();
        }
      }
    }
