	public IEnumerable<long> GetObjects()
	{
		return Observable
			.Interval(TimeSpan.FromSeconds(1.0))
			.Finally(() => Console.WriteLine("Done."))
			.ToEnumerable();
	}
	
	public void Test()
	{
		foreach (long i in GetObjects())
		{
			Console.WriteLine(i);
			if (i == 10)
			{
				break;
			}
		}
	}
