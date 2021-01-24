    void Main()
    {
    	Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(GetPerson()));
    }
    
    public dynamic GetPerson()
    {
    	const bool FirstNameRequired = true; // TODO: Parse querystring
    	
    	dynamic rtn = new ExpandoObject();
    	
    	if (FirstNameRequired)
    		rtn.first_name = "Steve";
    		
    	return rtn;
    }
