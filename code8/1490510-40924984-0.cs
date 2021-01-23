    List<DropOptions> listOfOptions = new List<DropOptions>();
    foreach (Dictionary<string, Dictionary<string, Dictionary<string, int>>> item in tempListOfOptions)
    {
    	foreach (Dictionary<string, Dictionary<string, int>> item1 in item.Values)
    	{
    		DropOptions objDrop = new DropOptions();
    		objDrop.fieldName = item.Select(t => t.Key).FirstOrDefault();
    		objDrop.fieldOptions = new Dictionary<string, int>();
    		foreach (Dictionary<string, int> item2 in item1.Values)
    		{
    			string strKey = item2.Select(t => t.Key).FirstOrDefault();
    			int strValue = item2.Select(t => t.Value).FirstOrDefault();
    
    			objDrop.fieldOptions.Add(strKey, strValue);
    		}
    		listOfOptions.Add(objDrop);
    	}
    }
