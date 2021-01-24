	void Main()
	{
		var coldStatusPollerObservable =
		    from tick in Observable.Interval(TimeSpan.FromMilliseconds(1000))
		    from status in
				Observable
					.FromAsync(() => client.GetStatus(1))
					.Catch<string, Exception>(ex => Observable.Return("Error"))
		    select status;
			
		coldStatusPollerObservable.Subscribe(x => x.Dump(), ex => ex.Message.Dump());
	}
	
	public static class client
	{
		private static int _counter = 0;
		public static Task<string> GetStatus(int id)
		{
			if (_counter++ == 5)
				throw new Exception();
			return Task.Run(() => _counter.ToString());
		}
	}
