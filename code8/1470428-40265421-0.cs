    var text = File.ReadAllText("$settingsfile");
    var keyValuePairs = text.Split('\n')
    	.Select(line => Tuple.Create(line.Split('=')[0].Trim(), line.Split('=')[1].Trim()));
    
    dynamic root = new ExpandoObject();
    
    foreach (var tup in keyValuePairs)
    {
    	var path = tup.Item1.Split('.').Skip(1).ToList();
    	var setting = path.Last();
    	var value = tup.Item2;
    	
    	IDictionary<string, object> resolvedObject = root;
    	
    	foreach (var component in path.Take(path.Count - 1))
    	{
    		if (!resolvedObject.ContainsKey(component))
    		{
    			resolvedObject.Add(component, new ExpandoObject());
    		}
    		
    		resolvedObject = (IDictionary<string, object>) resolvedObject[component];
    	}
    	
    	resolvedObject[setting] = value;
    }
    
    Console.WriteLine(">> " + root.System.BoaPort);
