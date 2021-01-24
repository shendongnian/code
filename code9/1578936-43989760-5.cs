	async Task<double> DoSomethingAsync()
	{
		double x = await ReadXFromFile();
		
		Task<double> a = LongMathCodeA(x);
		Task<double> b = LongMathCodeB(x);
		
		await Task.WhenAll(a, b);
		
		return a.Result + b.Result;
	}
