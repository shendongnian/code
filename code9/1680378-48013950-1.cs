    void Main()
    {
    	var drivers = new Dictionary<string, Driver>();
    	drivers.Add("van", new Driver());
    	drivers.Add("ric", new Driver());
    	// ... etc.
    	
    	foreach(var driver in drivers)
    	{
    		if(driver.Value.Position == 2)
    		{
    			// Do something
    		}
            if(driver.Key == "van")
            {
                // Do something else
            }
    	}
    }
