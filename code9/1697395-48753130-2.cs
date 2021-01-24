    class MyObject
    {
    	public long Id;
    	public long NextId;
    	public override string ToString() => Id.ToString();
    };
    
    public void q48710242()
    {
    	var items = new[]
    	{
    		new MyObject{ Id = 1, NextId = 3 },
    		new MyObject{ Id = 2, NextId = 0 },
    		new MyObject{ Id = 3, NextId = 17 },
    		new MyObject{ Id = 17, NextId = 2 }
    	};
    
    	var nextIdIndex = items.ToDictionary(item => item.NextId);
    	var orderedSteps = new List<MyObject>();
    
    	var currentStep = new MyObject() { Id = 0 };
    	while (nextIdIndex.TryGetValue(currentStep.Id, out currentStep))
    	{
    		orderedSteps.Add(currentStep);
    	}
    	orderedSteps.Reverse();
    
    	var output = string.Join(", ", orderedSteps);
    }
