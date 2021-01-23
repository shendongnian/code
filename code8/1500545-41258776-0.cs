    [HttpGet, Route("testasync")]
    public string CallTestAsync()
    {
    	Task t = TestAsync();
    	string response = "";
    	
    	if (t.IsFaulted)
    	{
    		response = t.Exception.InnerException.Message;
    	}
    	else
    	{
    		response = "Success";
    	}
    	return response;
    }
