    ...
    using System.ComponentModel;
    ...
    public partial class YourForm : Form
    {
        BackgroundWorker dbWorker;
        ...
        public YourForm()
        {
            ...
            dbWorker = new BackgroundWorker();
            dbWorker.DoWork += new DoWorkEventHandler(dbWorker_DoWork);
            dbWorker.ProgressChanged += new ProgressChangedEventHandler(dbWorker_ProgressChanged);
            dbWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(dbWorker_RunWorkerCompleted);
            dbWorker.WorkerReportsProgress = true;
            dbWorker.WorkerSupportsCancellation = true;
            ...
        }
        ...
        public void dbWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // This is where you put your GetTableToDataGridView() code.
            // Add a line inside the loop, for reporting on progress:
            // dbWorker.ReportProgress((int)(currentIteration * 100 / totalIterations));
            // At the end of the process, set the progress bar to 100% (optional)
            dbWorker.ReportProgress(100);
        }
        public void dbWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            
            // Here you can also do other things, which depend on the progress. 
            // eg: Set your label text to the current value of the progress bar.
        }
        public void dbWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Process Cancelled.");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error occurred: "+ e.Error.Message.");
            }
            else
            {
                MessageBox.Show("Successful Completion.");
            }
            progressBar.Value = 0;
        } 
    }
