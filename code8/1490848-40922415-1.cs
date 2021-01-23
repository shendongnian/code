	var webservices = new Func<Task<bool>>[]
	{
		WebService1, WebService2, WebService3, WebService4,
	};
	IObservable<bool> query =
		webservices
			.ToObservable()
			.SelectMany(ws => Observable.FromAsync(ws))
			.Where(b => b == true)
			.Take(1);
	IDisposable subscription = query.Subscribe(b => PostProcessing());
