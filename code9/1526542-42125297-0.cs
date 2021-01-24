	var timestampedObjects = Enumerable.Range(0, 5)
		.Select(i => Timestamped.Create(i, DateTimeOffset.Now + TimeSpan.FromSeconds(i*i)))
		.ToList();
		
	var observable = timestampedObjects.ToObservable()
		.SelectMany(t => Observable.Timer(t.Timestamp).Take(1).Select(_ => t.Value));
	observable.Subscribe(i => Console.WriteLine($"{DateTimeOffset.Now}: {i}"));
