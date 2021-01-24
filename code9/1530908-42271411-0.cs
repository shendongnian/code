    [Authorize]
    [HttpGet]
    [Route("{type}/")]
    public IHttpResponse GetCustomerDetails(string type)
    {
    	var user = RequestContext.Principal.Identity.Name;
       //my api stuff
    }
