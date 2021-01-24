    public void Main()
    {
         //The instance of the class with the variable for your progress bar
         ALMBerekeningen almBerekeningen = new ALMBerekeningen();
         BackgroundWorker bgw = new BackgroundWorker();
         bgw.DoWork += bgw_DoWork;
         //Pass your class instance in here
         bgw.RunWorkerAsync(almBerekeningen);
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        //e.Argument is the instance of the class you passed in
        var progressPerc = (ALMBerekeningen)e.Argument;
        int sims;
        sims = progressPerc.ProgressPerc;
        try
        {
            backgroundWorker1.ReportProgress(sims);
        }
        catch (Exception ex)
        {
            backgroundWorker1.CancelAsync();
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
