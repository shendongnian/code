    string json = string.Empty;
    using (StreamReader r = new StreamReader("Sample.json"))
    {
    	json = r.ReadToEnd();
    }
    dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
    
    foreach (var set in jsonObj)
    {
    	if ((set).Name.Contains("PL_DATA_HL"))
    	{
    		object value = (set).Value;
    		dynamic jsonValues = Newtonsoft.Json.JsonConvert.DeserializeObject(value.ToString());
    		Console.WriteLine("Values for " + (set).Name);
    		foreach (var jsonValue in jsonValues)
    		{
    			var items = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonValue.ToString());
    			foreach (var item in items)
    			{
    				if((item).Name == "value")
    					Console.WriteLine((item).Value);
    			}
    		}                    
    	}
    }
