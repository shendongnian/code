    public void q48710242()
    {
    	var items = new []
		{
    		new { Id = 1, NextId = 3 },
    		new { Id = 2, NextId = 0 },
    		new { Id = 3, NextId = 17 },
    		new { Id = 17, NextId = 2 }
    	};
    
    	var nextIdIndex = items.ToDictionary(item => item.NextId, item => item.Id);
    	var orderedSteps = new List<int>();
    
    	var currentStep = 0;
    	while (nextIdIndex.TryGetValue(currentStep, out currentStep))
    	{
    		orderedSteps.Add(currentStep);
    	}
    
    	orderedSteps.Reverse();
    
    	var output = string.Join(", ", orderedSteps);
    }
