	public IObservable<ResultWithProgress<string>> Calculate3()
	{
		return Observable.Create<ResultWithProgress<string>>(obs =>
		{
			var query =
				from b in new int[] { 1, 2, 3, 4 }.ToObservable()
				from x in Observable.Start(() => "BLAH" /* expensive operation here in the future */)
				select new ResultWithProgress<string>()
				{
					Progress = 25 * b,
					Result = x,
					ProgressText = "Completed " + b,
				};
	
			return query.Subscribe(obs);
		});
	}
