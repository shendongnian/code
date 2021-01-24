    void Main()
    {
    	var subject = new Subject<string>();
    	
    	IDisposable disposable =
    		subject
    			.Select(input => int.Parse(input))
    			.SelectMany(inputInt => Observable.FromAsync(() => CalcAsync(inputInt)))
    			.Subscribe(x => Console.WriteLine(x));
    	
    	subject.OnNext("1");
    	subject.OnNext("2");
    	subject.OnNext("3");
    	subject.OnNext("4");
    	subject.OnNext("5");
    	subject.OnNext("6");
    	subject.OnCompleted();
    }
    
    private int _counter = 0;
    
    public async Task<int> CalcAsync(int x)
    {
    	if (_counter++ == 3)
    	{
    		throw new Exception();
    	}
    	return await Task.Factory.StartNew(() => -x);
    }
