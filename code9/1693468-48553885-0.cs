	async void Main()
	{
		SetupObservable();
	
		var test2 =
			await
				_jobQueue
					.Take(2)
					.Do(x =>
					{
						CurrentJob.Status.ShouldBeEquivalentTo("OK");
						Console.WriteLine(CurrentJob.Status); //Ouptuts "OK" and "OK" as expected
					})
					.ToArray();
	}
	
	public void SetupObservable()
	{
		_jobQueue =
			Observable
				.Interval(TimeSpan.FromMilliseconds(500))
				.SelectMany(_ => Observable.FromAsync(UpdateJob))
				.Where(gotNewJob => gotNewJob == true) // only accept new jobs.
				.Do(gotNewJob => _logger.Information("some info"))
				.Select(_ => Unit.Default);
	}
