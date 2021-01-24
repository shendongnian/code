    var items = new List<object>();
    
    var testObjectOne = new
    {
    	Valueone = "test1",
    	ValueTwo = "test2",
    	ValueThree = "test3"
    	};
    var testObjectTwo = new
    {
    	Valueone = "test1",
    	ValueTwo = "test2",
    	ValueThree = "test3"
    };
    items.Add(testObjectOne);
    items.Add(testObjectTwo);
    
    foreach (var obj in items)
    {
    	var val = obj.GetType()
    		.GetProperty("Valueone")
    		.GetValue(obj);
    }
