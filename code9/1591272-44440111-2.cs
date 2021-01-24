    [ActionName("GetIndex")]
    [HttpGet]
    public HttpResponseMessage IndexIdById(string id)
    {
    ... other relative code here ...
    var response = new HttpResponseMessage(HttpStatusCode.OK);
    return response;
    }
