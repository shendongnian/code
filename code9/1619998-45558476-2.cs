	void Main()
	{
		int[] source = new [] { 1, 2, 3 };
		
		var query =
			from s in source.ToObservable()
			from u in Observable.FromAsync(() => Func(s))
			select new { s, u };
		
		IDisposable subscription =
			query
				.Subscribe(
					x => Console.WriteLine($"!{x.s},{x.u}!"),
					() => Console.WriteLine("Done."));
	}
	
	public async Task<int> Func(int x)
	{
		Console.WriteLine($"+{x} ");
		await Task.Delay(TimeSpan.FromSeconds(1.0));
		Console.WriteLine($" {x}-");
		return 10 * x;
	}
