    [HttpPost]
    public HttpResponseMessage Get(string url)
    {
        string responseString = GetWebApiData(url);
        if (!string.IsNullOrEmpty(responseString) && responseString.ToString().IsValid())
        {
            return Request.CreateResponse("Valid"); // I'd suggest returning an object here to be serialised to JSON or XML
        }
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid");
    }
