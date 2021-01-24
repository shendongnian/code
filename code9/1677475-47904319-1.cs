    var model = new MyViewModel
    {
    	SingleInteger = 1,
    	MultipleInts = new List<int>(){ 1,2,3 },
    	AssembledClass = new List<MySubclass>{
    		new MySubclass 
    		{
    			Quantity = 1,
    			Type = 2
    		}
    	},
    	MultipleStrings = new List<string>(){ "one", "two"} 
    };
