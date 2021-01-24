    Dictionary<string, int> themes = new Dictionary<string, int>();
    
    for (int i = 0; i < list.Count; i++)
    {
    	if(themes.ContainsKey(list[i].Theme))
    		themes[this[i].Theme]++;
    	else
    		themes[this[i].Theme = 1;
    }
    
    foreach(var keyValuePair in themes){
    	Console.WriteLine("{0} {1}", keyValuePair.Key, keyValuePair.Value);
    }
	
