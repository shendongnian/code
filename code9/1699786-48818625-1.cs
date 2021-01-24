    public async Task<HttpResponseMessage> Post()
    {
        var requestStream = await Request.Content.ReadAsStreamAsync();
        var contentType = Request.Content.Headers.ContentType;
        //store content-type and contents of requestStream
        return Request.CreateResponse(HttpStatusCode.Created);
    }
