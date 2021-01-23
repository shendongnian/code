    public static void AddResourceContent(Dictionary<string,string> a)
    {
    	foreach(string key in a.Keys)
    	{
    		using (ResXResourceWriter resx = new ResXResourceWriter(@".\StringResources.resx"))
    		{
    			resx.AddResource(key, a[key]);
    		}
    	}
    }
