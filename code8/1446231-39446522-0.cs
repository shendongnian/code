    public partial class formStudent {
       boolean workerRunningStatus = false;
        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            // Path output file CSV
            string pathFile = @"D:\DataTest\ListStudent.csv";
            int filesCount = 3;
            // Check if the backgroundWorker is already busy running the asynchronous operation
            if (!workerRunning)
            {
                btnExportCsv.Enabled = false;
                // This method will start the execution asynchronously in the background
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                workerRunningStatus = true;
                //then exit
                return;
            }
            //Continue with the remaining logic
         }
    }
