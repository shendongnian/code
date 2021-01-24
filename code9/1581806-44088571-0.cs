    public override void Validate(string userName, string password)
    {
    	try
    	{
    		if (userName == "test" && password == "test123")
    		{
    			Console.WriteLine("Authentic User");
    		} else {
    			throw new Exception();
    		}
    	}
    	catch (Exception ex)
    	{
    		throw new FaultException("Unknown Username or Incorrect Password");
    	}
    }
