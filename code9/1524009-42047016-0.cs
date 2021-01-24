	public async Task<object> Method()
	{
		cts = new CancellationTokenSource();
		await methodAsync(cts.Token);
		return "message";
	}
	
	public Task<object> methodAsync(CancellationToken ct)
	{
		for (var i = 0; i < 1000000; i++)
		{
			if (ct.IsCancellationRequested)
			{
				break;
			}
			//Do a small part of the overall task based on `i`
		}
		return result;
	}
