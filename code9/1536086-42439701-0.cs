    Dictionary<int, int> noDuplicates = new Dictionary<int, int>();
    foreach (var item in dictionaryLIndex)
    {
    	if (!noDuplicates.ContainsValue(item.Value))
    	{
    		noDuplicates.Add(item.Key,item.Value);
    	}
    }
