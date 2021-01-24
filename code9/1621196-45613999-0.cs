    public static Task LoadPageAsync(IWebBrowser browser)
	{
		var tcs = new TaskCompletionSource<bool>();
		EventHandler<LoadingStateChangedEventArgs> handler = null;
		handler = (sender, args) =>
		{
			if (!args.IsLoading)
			{
				browser.LoadingStateChanged -= handler;
				tcs.TrySetResultAsync(true);
			}
		};
		browser.LoadingStateChanged += handler;
		return tcs.Task;
	}
   
