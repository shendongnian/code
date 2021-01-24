	void Main()
	{
		var period = TimeSpan.FromSeconds(0.5);
		var observable = Observable
			.Interval(period)
			.Publish()
			.RefCount();
	
		var a = observable.Select(i => ComplexComputation1(i).ToObservable())
					.Concat();
		var b = observable.Select(i => ComplexComputation2(i).ToObservable())
					.Concat();
	
		a.Zip(b, Tuple.Create)
			.Subscribe(pair => FinalAction(pair.Item1, pair.Item2));
	}
	
	// Define other methods and classes here
	Random rnd = new Random();
	private async Task<long> ComplexComputation1(long i)
	{
		await Task.Delay(rnd.Next(50, 1000));
		return i;
	}
	private async Task<long> ComplexComputation2(long i)
	{
		await Task.Delay(rnd.Next(50, 1000));
		return i;
	}
	
	private void FinalAction(long a, long b)
	{
	
	}
