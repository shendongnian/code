    private void MethodThatCallsGetAlertGrid()
    {
        // Show the progress bar and set the style of progress bar to Marquee. This will show continiously scrolling block across progress bar, as you cannot know the current progress percent
        this.progressBar1.Visible = true;
        this.progressBar1.Style = ProgressBarStyle.Marquee;
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
