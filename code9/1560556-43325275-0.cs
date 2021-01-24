    void Main()
    { 
    
    	var incomeList = new List<Income>();
    	Income obj = new Income();
    	obj.Month1 = 200;
    	obj.Month2 = 150;
    
    	incomeList.Add(obj);
    
    	var results = incomeList
    		.Select(x => new
    		{
    			Months = new int[]
    			{
    				x.Month1,
    				x.Month2,
    				x.Month3,
    				x.Month4,
    				x.Month5
    			}
    		})
    	 .ToArray();
    
    
    	for (int i = 0; i < results.Length; i++)
    	{
    		var testResults = results[i];
    		Console.WriteLine($"Month 1: {testResults.Months[0]}");
    		Console.WriteLine($"Month 2: {testResults.Months[1]}");
    		Console.WriteLine($"Month 3: {testResults.Months[2]}");
    		Console.WriteLine($"Month 4: {testResults.Months[3]}");
    		Console.WriteLine($"Month 5: {testResults.Months[4]}");
    	}
    }
