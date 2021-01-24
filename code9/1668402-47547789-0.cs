    var rx = @"(?<term>\w+(?:\s+\w+)*)(?:\s+(?<key>\w+)=""(?<value>[^""]*)"")+";
    var s = "John Hennesey POLICY_NUMBER=\"POL-1-2345-6-780\" EXPIRATION_DATE=\"2017-01-01T00:00:00\" business_name=\"Hennesey Hen Houses\" PREMIUM=\"between 100 and 400\"  Mike Ramsey POLICY_NUMBER=\"POL-2-2346-8-080\" EXPIRATION_DATE=\"2017-02-08T01:04:50\" business_name=\"Mike Ramsey Igloos\" PREMIUM=\"between 200 and 500\"";
    var ms = Regex.Matches(s, rx);
    foreach (Match m in ms)
    {
		var term = m.Groups["term"].Value;
    	Dictionary<string, string> dct = m.Groups["key"].Captures // Get Group "term" capture collection
    			.Cast<Capture>()
    			.Select(x=>x.Value)           // Convert to a list of values
    			.ToList()
    			.Zip(                         // Zip with the Group "value" substrings to get a dictionary
    				m.Groups["value"].Captures.Cast<Capture>().Select(x=>x.Value).ToList(), 
    				(k, v) => new { k, v }
    			)
       			.ToDictionary(x => x.k, x => x.v);
    	Console.WriteLine("---- NEXT MATCH ----\nTerm: {0}", term); // Demo output
        foreach (var kvp in dct) 
        {
        	Console.WriteLine("KVP: {0}:{1}", kvp.Key, kvp.Value);
        }
    }
