    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        try
        {
            int b = 0; //simulate error
            for (int i = 1; i <= 10; i++)
            {
                if (worker.CancellationPending == true)
                {
                    string[] array2 = { "1", "cancelled" };
                    e.Result = array2; //passing values when user cancel through e.Result object
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    worker.ReportProgress(i * 10, "Test a");
                    int a = 1 / b; //simulate error
                    System.Threading.Thread.Sleep(1000);
    
                }
                string[] array1 = {"1","done"};
                e.Result = array1; //passing values when complete through e.Result object
            }
        }
        catch (Exception e)
        {
            throw new BackgroundWorkerException("1", e);
        }
    }
