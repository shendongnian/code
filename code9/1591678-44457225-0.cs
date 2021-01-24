    private void ProcessResource()
    {
    	var resxFile = @"..\..\Resource1.de-DE.resx";
    	var destResxFile = @"..\..\Resource1.ru-RU.resx";
    
    	using (var reader = new ResXResourceReader(resxFile))
    	{
    		using (var writer = new ResXResourceWriter(destResxFile))
    		{
    			foreach (DictionaryEntry entry in reader)
    			{
    				writer.AddResource(entry.Key.ToString(), Translate(entry.Value.ToString()));
    			}
    		}
    	}
    }
    
    private string Translate(string value) => "translated " + value;
