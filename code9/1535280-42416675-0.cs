    void Main()
    {
    	List<int> intlist = new List<int>
    	{
    		1,
    		1,
    		1,
    		2,
    		2,
    		3,
    		4,
    		4,
    		4,
    		4
    	};
    
    
    	var dict = new Dictionary<int, int>();
    	foreach (var item in intlist)
    	{
    		if (!dict.ContainsKey(item)) // this checks for the existance of an item
    		{
    			dict.Add(item, 0); // this initialises the item in the dictionary
    		}
    		dict[item]++; // this will update the count of the item
    	}
    
        // this is just for linqpad debug output and shows each value and their count
        // this can be achieved with foreach
    	dict.Select(x => new { x.Key, x.Value}).Dump();
    }
