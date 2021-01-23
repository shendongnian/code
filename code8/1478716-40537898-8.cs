    void Consumer()
    {
    	//var results = GetValuesComplex();
    	//var results = GetValuesComplex().ToList();
    	var results = GetValuesComplex().Memoize();
    	
    	if(results.Any(i => i == 3)) 
    	{
    		Console.WriteLine("\nFirst Iteration");
    		//return; //Potential for early exit.
    	}
    	
    	var last = results.Last(); // Causes multiple enumeration in naive case.		
    	
    	Console.WriteLine("\nSecond Iteration");
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
