    public HttpResponseMessage Get()
    {
    	var list = context.Colors.ToList();
    	return Request.CreateResponse(HttpStatusCode.OK,list);
    }
