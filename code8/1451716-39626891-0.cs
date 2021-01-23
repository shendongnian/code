    void Main()
    {
    	var source = Observable.Range(1, 10);
    	var switcher = new Switch<int, int>(i => i % 3);
    	switcher[0] = Observer.Create<int>(val => Console.WriteLine($"{val} Divisible by three"));
    	source.Subscribe(switcher);
    }
    
    class Switch<TKey,TValue> : IObserver<TValue>
    {
    	private readonly IDictionary<TKey, IObserver<TValue>> cases;
    	private readonly Func<TValue,TKey> idExtractor;
    
    	public IObserver<TValue> this[TKey decision]
    	{
    	    get
    		{
    			return cases[decision];
    		}
    		set
    		{
    			cases[decision] = value;
    		}
    	}
    	
    	public Switch(Func<TValue,TKey> idExtractor)
    	{
    		this.cases = new Dictionary<TKey, IObserver<TValue>>();
    		this.idExtractor = idExtractor;
    	}
    	
    	public void OnNext(TValue next)
    	{
    		IObserver<TValue> nextCase;
    		if (cases.TryGetValue(idExtractor(next), out nextCase))
    		{
    			nextCase.OnNext(next);
    		}
    	}
    	
    	public void OnError(Exception e)
    	{
    		foreach (var successor in cases.Values)
    		{
    			successor.OnError(e);
    		}
    	}
    	
    	public void OnCompleted()
    	{
    		foreach (var successor in cases.Values)
    		{
    			successor.OnCompleted();
    		}
    	}
    }
