	try
	{
		Observable.Interval(TimeSpan.FromMilliseconds(100))
			.Take(10)
			.AsyncFinally(async () =>
			{
				await Task.Delay(1000);
				throw new NotImplementedException();
			})
			.Subscribe(i => Console.WriteLine(i));
	}
	catch(Exception e)
	{
		Console.WriteLine("Exception caught, no problem");
	}
