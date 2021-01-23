    public string[] passFiles(string location)
    {
        // Create an empty array that will be returned in case something goes wrong
    	string[] files = new string[0];
    	try
    	{
    		files = Directory.GetFiles(location);
    	}
    	catch (UnauthorizedAccessException)
    	{
    		// Code here will be hit if access is denied.
    	}
    	
        return files;
    }
