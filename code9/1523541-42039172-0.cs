    private void MethodThatCallsGetAlertGrid()
    {
        // Show the progress bar
        this.progressBar1.Visible = true;
        // Start loading the data source async
        Task.Factory.StartNew(() =>
            this.getAlertGrid())
       .ContinueWith((antecedent) =>
        {
            // Set data source on UI thread. Remove the same row from your getAlertGrid method
            ugAlert.DataSource = dtAlert;
            // Hide the progress bar
            this.progressBar1.Visible = false;
        }, TaskScheduler.FromCurrentSynchronizationContext());
