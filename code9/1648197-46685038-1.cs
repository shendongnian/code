	void Main()
	{
		var states = new Subject<bool>();
		
		IObservable<int> query =
			states
				.Select(state => state
					? Observable.FromAsync(() => GetStatusAsync())
					: Observable.Never<int>())
				.Switch();
	}
	
	public async Task<int> GetStatusAsync()
	{
		return await Task.Factory.StartNew(() => 42);
	}
