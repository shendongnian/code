    void Main()
    {
    	var counter = BelowValueCounter_UsingFor(46);
    	//var counter = BelowValueCounter_UsingLinq(46);
    	Console.WriteLine(counter);	
    }
    
    decimal[] temperatures = new decimal[] { 40, 40, 45, 60, 70 };
    
    public int BelowValueCounter_UsingLinq(decimal tempValueIn)
    {
    	return temperatures.Count(a => a < tempValueIn);	
    }
    
    public int BelowValueCounter_UsingFor(decimal tempValueIn)
    {
    	int counter = 0;
    	for (int i = 0; i < temperatures.Length; i++)
    	{
    		if (temperatures[i] < tempValueIn)
    			counter++;
    	}
    	
    	return counter;	
    }
    
