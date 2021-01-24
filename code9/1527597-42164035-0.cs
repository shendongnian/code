    public IHttpActionResult Get()
    {
       HttpResponseMessage responseMessage = "From HttpResponse";
       return new ResponseMessageResult(responseMessage);
    }
