    if (list1 != null)
    {
    	var keys = list2.Select(item => new { item.Name, item.Number }).ToHashSet();
    	foreach (var item in list1)
    	{
    		var key = new { item.Name, item.Number };
    		if (!keys.Contains(key))
    		{
    			list2.Add(item);
    			keys.Add(key);
    		}
    	}
    }
