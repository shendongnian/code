    void Consumer()
    {
    	//var results = GetValuesComplex();
    	//var results = GetValuesComplex().ToList();
    	var results = GetValuesComplex().Memoize();
    	
    	if(results.Any(i => i == 3))
    	{
    		Console.WriteLine("\nFirst Iteration: Potential for early exit.");
    		//return;
    	}
    	
    	var last = results.Last();		
    	
    	Console.WriteLine("\nSecond Iteration: Potential for multiple enumeration.");
    }
    
    IEnumerable<int> GetValuesComplex()
    {
    	for (int i = 0; i < 5; i++)
    	{
    		//... complex operations ...		
    		Console.Write(i + ", ");
    		yield return i;
    	}
    }
