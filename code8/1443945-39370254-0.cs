	async Task<int> ActionAsync(int i)
	{
	    if (i == 2)
	        throw new Exception();
	
	    return i;
	}
	
	void Main()
	{
	    var sb = new Subject<int>();
	
	    sb
			.SelectMany(ActionAsync)
			.Do(_ => { }, ex => ex.Dump())
			.Retry()
			.Subscribe(_ => _.Dump());
	
	    sb.OnNext(1);
	    sb.OnNext(2);
	    sb.OnNext(3);
	}
