	var ticker = Observable.Interval(TimeSpan.FromSeconds(1))
		.Publish().RefCount();
	var latestTickerValue = ticker.ToReactiveProperty();
	Console.WriteLine(latestTickerValue.Value);
	await Task.Delay(TimeSpan.FromSeconds(1));
	Console.WriteLine(latestTickerValue.Value);
	await Task.Delay(TimeSpan.FromSeconds(3));
	Console.WriteLine(latestTickerValue.Value);
