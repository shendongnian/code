	Observable
		.Zip(
			assets
				.ToObservable()
				.Do(file => imageControl.Source = new BitmapImage(new Uri(file.Path))),
			imageControl
				.Events()   // Extension class for my events
				.ImageOpened,
			(asset, _) =>
			{
				// Do some work ...
			})
		.Subscribe(
			_ => { },
			ex => System.Diagnostics.Debug.WriteLine("Error on subscribing to Zip"));
		.DisposeWith(_subscriptions);
