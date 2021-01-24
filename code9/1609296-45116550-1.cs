    [HttpGet]
    [WebApiAuthorizeAttribute(Roles="Admin")]      
    public async Task<HttpResponseMessage> TestMethod()
    {
        return Request.CreateResponse(HttpStatusCode.OK);
    }
