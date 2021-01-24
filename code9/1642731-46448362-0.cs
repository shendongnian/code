    void Main()
    {
    	Observable
    		.Generate(
    			0, // initialState
    			x => x < 10, //condition
    			x => x + 1, //iterate
    			x => x, //resultSelector
    			x => TimeSpan.FromSeconds(GetSeconds())) //timeSelector
    		.Timestamp()
    		.Subscribe(x => Console.WriteLine($"{x.Value} {x.Timestamp}"));
    }
    
    private double _seconds = 2.0;
    
    public double GetSeconds()
    {
    	if (++_seconds > 5.0)
    	{
    		_seconds = 2.0;
    	}
    	return _seconds;
    }
