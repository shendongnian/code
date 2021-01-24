    void Main()
    {
    	var source = UglyRange(10);
    	var target = source
    		.SelectMany(i => Observable.Return(i).Delay(TimeSpan.FromMilliseconds(10 * i)))
    		.ThrottleSubsequent2(TimeSpan.FromMilliseconds(70), Scheduler.Default) //Works with ThrottleSubsequent2, fails with ThrottleSubsequent
    		.Subscribe(i => Console.WriteLine(i));
    }
    static int counter = 0;
    public IObservable<int> UglyRange(int limit)
    {
    	var uglySource = Observable.Create<int>(o =>
    	{
    		if (counter++ == 0)
    		{
    			Console.WriteLine("Ugly observable should only be created once.");
    			Enumerable.Range(1, limit).ToList().ForEach(i => o.OnNext(i));
    		}
    		else
    		{
    			Console.WriteLine($"Ugly observable should only be created once. This is the {counter}th time created.");
    			o.OnError(new Exception($"observable invoked {counter} times."));
    		}
    		return Disposable.Empty;
    	});
    	return uglySource;
    }
