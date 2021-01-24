    public List<string> Messages { get; private set; }
    public HttpRequestMessage Request { get; private set; }
    
    public HttpResponseMessage Execute() {
        var response = Request.CreateResponse(HttpStatusCode.BadRequest, Messages);
        return response;
    }
