    public static void Store()
    {
    	string assetValue = HttpContext.Current.Request["asset"];
    	if (!string.IsNullOrEmpty(assetValue))
    		AssestsList.Add(assetValue);
    
    
    }
    
    public static List<string> AssestsList
    {
    	get
    	{
    		if (HttpContext.Current.Session["assets"] == null)
    		{
    			HttpContext.Current.Session["assets"] = new List<string>();
    		}
    		
    		return HttpContext.Current.Session["assets"] as List<string>;
    	}
    	set
    	{
    		HttpContext.Current.Session["assets"] = value;
    	}
    }
