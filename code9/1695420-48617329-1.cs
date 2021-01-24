	var progressView = new ProgressView(new CGRect(50, 50, 300, 50));
	Add(progressView);
	DispatchQueue.MainQueue.DispatchAsync(async () =>
	{
		while (progressView.Complete <= 1)
		{
			InvokeOnMainThread(() => progressView.Complete += 0.05);
			await Task.Delay(1000);
		}
	});
