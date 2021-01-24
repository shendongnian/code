	IObservable<List<PersonEntity>> query =
		Observable
			.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
				h => allStaff.CollectionChanged += h, h => allStaff.CollectionChanged -= h)
			.Throttle(TimeSpan.FromSeconds(2.0))
			.Select(x => allStaff.ToList())
			.ObserveOn(Scheduler.Default);
	IDisposable subscription =
		query
			.Subscribe(u =>
			{
				string containsWillBeSaved = "";
				// ...
				File.WriteAllText(fullPathToDataFile, containsWillBeSaved);
				System.Diagnostics.Debug.WriteLine("Data Save Successful");
			});
