    public dynamic GetPerson()
    {
    	bool firstNameRequired = true; // TODO: Parse querystring
    	bool lastNameRequired = false; // TODO: Parse querystring
    
    	dynamic rtn = new ExpandoObject();
    	
    	if (firstNameRequired)
    		rtn.first_name = "Steve";
    
    	if (lastNameRequired)
    		rtn.last_name = "Jobs";
        // ... and so on
    
    	return rtn;
    }
    void Main()
    {
        // Using the serializer of your choice:
    	Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(GetPerson()));
    }
