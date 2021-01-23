    // POST api/value
    [EnableCors("SiteCorsPolicy")]
    [HttpPost]
    public HttpResponseMessage Post([FromBody]Blog value)
    {
    	// Do something with the blog here....
    
    	var msg = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
    	return msg;
    
    }
