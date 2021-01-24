    async void Main()
    {
        var entities = new double[] { 1, 2, 4, 8, 16, 32 }.ToObservable();
    
        entities = Square(entities);
        entities = Print(entities);
        entities = Add(entities, 1);
        entities = SaveObservable(entities);
        entities = Add(entities, 2);
    
        await PrintAll(entities);
    }
    
    public IObservable<double> Square(IObservable<double> source)
        => source.Select(i => Math.Pow(i, 2.0));
    
    public IObservable<double> Add(IObservable<double> source, double add)
        => source.Select(i => i + add);
    
    public IObservable<T> Print<T>(IObservable<T> source)
        => source.Do(i => Console.WriteLine("Print: {0}", i));
    
    public IObservable<T> SaveObservable<T>(IObservable<T> source)
    {
    	return Observable.Create<T>(o =>
    	{
    		var last = default(T);
    		return 
    			source
    				.Do(
    					t => last = t,
    					() =>
    					{
    						Console.WriteLine("Collected observable and saving to the db. Last element is '{0}'", last);
    					})
    				.Subscribe(o);
    	});
    }
    
    public IObservable<double> PrintAll(IObservable<double> source)
        => source.Do(i => Console.WriteLine("PrintAll: {0}", i));
