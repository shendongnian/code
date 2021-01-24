    var groupedParams = _params.GroupBy(a => a.Name, StringComparer.InvariantCultureIgnoreCase).ToDictionary(t => t.Key);
    int i = 0;
    while (i != _params.Count)
    {
    	if (groupedParams.ContainsKey(parameter.Name))
        {
        	var temp = groupedParams[parameter.Name];
            if (temp.Count(x => x.PathType.ToLower() == "path") == 1 && temp.Count(x => x.PathType.ToLower() == "query") == 1)
            {
            	params.RemoveAt(i);
                continue;
            }
    	}
        i++;
    }
