	void Main()
	{
		EventLoopScheduler threadA = new EventLoopScheduler();
		IObservable<int> timer = Observable.Interval(TimeSpan.FromSeconds(5.0), threadA).Select(x => FunctionX());
		IDisposable subscription = timer.Subscribe(x => Console.WriteLine("timer: " + x));
		Thread.Sleep(TimeSpan.FromSeconds(12.5));
		int value = Observable.Start(() => FunctionX(), threadA).Wait();
		Console.WriteLine("value: " + value);
	}
	
	private int counter = 0;
	public int FunctionX()
	{
		Console.Write("ManagedThreadId: " + Thread.CurrentThread.ManagedThreadId + "; ");
		Console.Write(DateTime.Now.ToString("ss.ffff") + "; ");
		return ++counter;
	}
