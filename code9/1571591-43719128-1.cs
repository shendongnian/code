    [HttpPost]
    [ResponseType(typeof(string))]
    public HttpResponseMessage AddItem(HttpRequestMessage request)
    {
    	HttpResponseMessage response = null;
        string message = string.Empty;
    
    	try 
    	{
    		.....
    
    		message = "Item Successfully Added";
    	}
    	catch (Exception e)
        {
        	.....
    
            message = e.Message;
        }
        
        response = Request.CreateResponse<string>(HttpStatusCode.OK, message);
    	return response;
    }
