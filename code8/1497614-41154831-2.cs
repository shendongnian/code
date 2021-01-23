    void Main()
    {
    	var randomList = new List<int>();
    	var random = new Random(1969);
    
    	for (var i = 0; i < 10; i++)
    	{
    		randomList.Add(random.Next(0, 500));
    	}
        // Use the values from the original post for validation
    	randomList = new List<int> { 190, 279, 37, 413, 90, 131, 64, 129, 287, 172 };
    	
    	const int numSets = 9;
    	var avgDict = Enumerable.Range(1, numSets).ToDictionary(e => e, e => (double)0);
    	var s = new Stack<int>();
    	foreach (var item in randomList)
    	{
    		s.Push(item);
    		for (var i = 1; i <= numSets; i++)
    		{
    			if (s.Count >= i)
    			{
    				var avg = s.Take(i).Average();
    				if (avg > avgDict[i])
    					avgDict[i] = avg;
    			}
    		}
    	}
    	avgDict.Dump();
    }
