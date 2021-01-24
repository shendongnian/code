    public HttpResponseMessage GetByMsn(string msn, DateTime dt)
    {
    	try
    	{		
    		var before = dt.AddMinutes(-5);
    		var after = dt.AddMinutes(5);
    		
    		var result = medEntitites.tj_xhqd
    		.Where(m => 
    			m.zdjh == msn &&
    			m.sjsj >= before &&
    			m.sjsj <= after)
    		.Select(m=> new { m.zdjh , m.sjsj, m.xhqd }).Distinct());
    		
    		return Request.CreateResponse(HttpStatusCode.Found, result);
    	}
    	catch (Exception ex)
    	{
    		return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
    	}
    }
