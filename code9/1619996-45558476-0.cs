	void Main()
	{
		int[] source = new [] { 1, 2, 3 };
		
		IObservable<int> query =
			from s in source.ToObservable()
			from u in Observable.Start(() => Func(s))
			select s;
		
		IDisposable subscription =
			query
				.Subscribe(
					x => Console.WriteLine($"!{x}!"),
					() => Console.WriteLine("Done."));
	}
	
	public void Func(int x)
	{
		Console.WriteLine($"+{x} ");
		Thread.Sleep(TimeSpan.FromSeconds(1.0));
		Console.WriteLine($" {x}-");
	}
