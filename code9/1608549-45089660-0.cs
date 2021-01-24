    var counts = new Dictionary<string, int>(pathList.Count); // specify max capacity to avoid rehashing
    foreach (string item in pathList)
    {
    	// Do some stuff here and pick 'item' only if it fits some criteria.
    	if (IsValid(item))
    	{
    		int count;
    		counts.TryGetValue(item, out count);
    		counts[item] = ++count;
    		duplicateItems.Add(item + "[" + count + "]");
    	}
    }
