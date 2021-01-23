	// Add the async keyword to our event handler
	private async void Button_Click(object sender, RoutedEventArgs e)
	{
		//Begin our Task
		Task downloadTask = DownloadFile();
		// Await the task
		await downloadTask;
	}
	private async Task DownloadFile()
	{
		// Capture the UI context to update our ProgressBar on the UI thread
		IProgress<int> progress = new Progress<int>(i => { LoadProgress.Value = i; });
		// Run our loop
		for (int i = 0; i < 100; i++)
		{
			int localClosure = i;
			// Simulate work
			await Task.Delay(1000);
			// Report our progress
			progress.Report((int)((double)localClosure / 100 * 100));
		}
	}
