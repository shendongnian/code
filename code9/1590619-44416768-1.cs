    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        bool onLine = (bool)e.Result;
        if (onLine)
        {
            operationCompleted();
        }
        else
        {
            MessageBox.Show("Error");
        }
    }
