	async Task SomeAsyncMethod()
	{
		(await Foo()).ThrowIfNull("hello");
	}
	
	public Task<int> Foo()
	{
		return Task.FromResult(0);
	}
