	public int GetAllInformationWithTimer()
	{
		using (Observable.Interval(TimeSpan.FromSeconds(1.0))
			.Subscribe(x => 
				Console.WriteLine("Elapsed Time: {0} seconds", x + 1)))
		{
			return GetAllInformation();
		}	
	}
