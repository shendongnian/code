    [HttpPost]
    [ResponseType(typeof(string))]
    public HttpResponseMessage AddItem(HttpRequestMessage request)
    {
    	HttpResponseMessage message = null;
    
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
        
    	return Request.CreateResponse<string>(HttpStatusCode.OK, message);
    }
