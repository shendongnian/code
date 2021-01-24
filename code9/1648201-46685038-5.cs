	void Main()
	{
	    var states = new Subject<bool>();
	
	    IObservable<int> query =
	        states
	            .Select(state => state
	                ? Observable
						.Interval(TimeSpan.FromSeconds(2.0))
						.StartWith(-1L)
						.SelectMany(n =>
							Observable.FromAsync(() => GetStatusAsync()))
	                : Observable.Never<int>())
	            .Switch();
	}
	
	public async Task<int> GetStatusAsync()
	{
	    return await Task.Factory.StartNew(() => 42);
	}
