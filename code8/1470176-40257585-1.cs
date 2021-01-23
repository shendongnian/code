    private void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
        int result = 2+2;
        e.Result = result;
    }
    
    private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        int result = (int)e.Result;
        MessageBox.Show("Result received: " + result.ToString());
    }
