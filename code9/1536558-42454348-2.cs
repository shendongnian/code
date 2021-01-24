    [Route("user/{role?}")]
    public HttpResponseMessage Get(string role)
    {
        return Request.CreateResponse(HttpStatusCode.OK, "Get me on role");
    }
