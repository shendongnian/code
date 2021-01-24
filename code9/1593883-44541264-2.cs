    private void start_Click(object sender, RoutedEventArgs e)
    {
    	...
    	Progress<int> progressIndicator = new Progress<int>(ReportProgress);
        cts = new CancellationTokenSource();
    	await MyAsyncTask(progressIndicator, cts.Token);
    	...
    }
    
    void ReportProgress(int value)
    {
    	// Cancel if no progress
    }
