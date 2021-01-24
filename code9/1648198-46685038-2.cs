	void Main()
	{
	    var states = new Subject<bool>();
	
	    IObservable<int> query =
		(
			from n in Observable.Interval(TimeSpan.FromMinutes(1.0))
			from ms in Observable.FromAsync(() => GetMachineStateAsync())
	        select ms
	            ? Observable.FromAsync(() => GetStatusAsync())
	            : Observable.Never<int>()
		).Switch();
	}
	
	public async Task<int> GetStatusAsync()
	{
	    return await Task.Factory.StartNew(() => 42);
	}
	
	public async Task<bool> GetMachineStateAsync()
	{
	    return await Task.Factory.StartNew(() => true);
	}
