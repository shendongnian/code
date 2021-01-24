	public static List<int> RemoveSmallest(List<int> numbers)
	{
		var newList = new List<int>();
        if (numbers != null && numbers.Count > 0)
        {
    		var lowest = numbers[0];
    		for (var i = 1; i < numbers.Count; i++)
	    	{
		    	if (numbers[i] < lowest) {
			    	lowest = numbers[i]
    			}
	    	}
    		foreach (var num in numbers)
	    	{
		    	if (num != lowest)
			    {
    				newList.Add(num);
	    		}
		    }
	    }
    	return newList;
    }
