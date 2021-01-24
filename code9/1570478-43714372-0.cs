    void Main()
    {
    	var s = new Subject<int>();
    		s.Select(Check)
    		    .Retry()
    		    .Subscribe(x => Console.WriteLine(x));
    	
    	s.OnNext(50);
    	s.OnNext(500);
    }
    
    int Check(int value)
    {
        if (value < 100)
            throw new Exception();
        return value;
    }
