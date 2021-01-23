	public IObservable<bool> DoStuff(/*args*/)
	{
		return Observable.Create<bool>(o =>
		{
			var subscription =
				Observable
					.FromEventPattern<EventHandler, EventArgs>(
						h => myService.StuffComplete += h,
						h => myService.StuffComplete -= h)
					.Select(x => myService.Status)
					.Take(1)
					.Subscribe(o);
			myService.DoStuff();
			return subscription;
		});
	}
