    public HttpResponseMessage Post([FromBody]QueryModel model)
    {
        var data = _svc.Query(model);
    
        var resp = Request.CreateResponse(HttpStatusCode.OK, data);
        resp.Content.Headers.Add("X-Moo", "Boo");
        return resp;
    }
