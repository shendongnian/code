    [Route("getFileStream")]
    [HttpGet]
    public Customer GetFileStream(Guid fileId)
    {
        // get the stream to return:
        System.IO.Stream myStream = ...
        // get the request from base class WebApi, to create an OK response
        HttpResponseMessage responesMessage = this.Request.CreateResponse(HttpStatusCode.OK);
        responseMessage.Content = new StreamContent(myStream);
        // use extra parameters if non-default buffer size is needed
        return responseMessage;
    }
