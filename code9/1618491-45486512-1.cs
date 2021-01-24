    void InsertIDsNamesAndAddWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // check if we're not cancelled or error-ed before checking the Result
        result = (!e.Cancelled && e.Error == null)? (bool) e.Result: false; // what is the outcome
        ProgressBarValue = 100;
        if (result) {
            StatusLable = "Done Processing.";
            if (System.Windows.MessageBox.Show("Done Processing.", "Status", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                StatusLable = string.Empty;
                ProgressBarValue = 0;
            }
        } 
        else 
        {
             StatusLable = "Error in Excel sheet";
        }
    }
