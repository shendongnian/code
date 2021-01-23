    var groupedItems;
    try
    {
    	groupedItems= inputFiles.GroupBy(q => q.Name.ToLower().Split('_').ElementAt(2));
    
    	string currentNo = ////value retreived from someMethod;
    	if (string.IsNullOrEmpty(currentNo) && groupedItems.Count() == 1)
    	{
    		ProcessFile();
    	}
    	else
    	{
    		foreach (var group in groupedItems.Where(x => string.IsNullOrEmpty(currentNo) || x.Key != currentNo))
    		{
    			foreach (var groupedItem in group)
    			{
    				ErrorFile(groupedItem);
    			}
    		}
    	}
    }
    catch
    {
    	ErrorFile(groupedItem);
    }
