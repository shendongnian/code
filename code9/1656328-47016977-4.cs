    private void Window_Loaded(object sender, RoutedEventArgs e)
	{
		DispatcherTimer startupTimer = new DispatcherTimer();
		startupTimer.Tick += new EventHandler((o, a) => {
			MyFunction();
			startupTimer.Stop();
		});
		startupTimer.Interval = TimeSpan.FromSeconds(1);
		startupTimer.Start();
	}
