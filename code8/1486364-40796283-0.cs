	var query =
		Observable
			.Range(0, 50)
			.Select(i => string.Format(pageFormat, i))
			.Select(u => Observable.Using(
				() => new WebClient(),
				wc => Observable.Start(() => new { url = u, content = wc.DownloadString(u) })))
			.Merge(5);
	IDisposable subscription = query.Subscribe(x =>
	{
		Console.WriteLine(x.url);
		Console.WriteLine(x.content);
	});
