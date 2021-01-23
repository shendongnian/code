    private void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
        //Do your work
        e.Result = mylist;
    }
    
    private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if(e.Error != null)
        {
            MessageBox.Show(e.Error.ToString());
        }
        else
        {
            ShowResult(e.Result as List<string>);
        }
    }
