    [HttpGet]
    [Route("foo/bar/{string element}")]
    public HttpResponseMessage TestMethod(string element)
    {
    //TODO: Implement
    return new HttpResponseMessage(HttpStatusCode.OK);
    }
