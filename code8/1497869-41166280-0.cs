    [HttpGet]
    public HttpResponseMessage Test([FromUri] TestRequest? request)
    {
    	if(request.HasValue)
    	{
    		//Do your thing
    	}
    }
