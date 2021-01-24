    public IHttpActionResult Get(string type = null)
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK);
        if (type == "json")
        {
            response.Content = new StringContent(JsonConvert.SerializeObject(websites));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
        else if (type == "xml")
        {
            response.Content = new StringContent("<xmlTag>Value</xmlTag>");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
        }
            
        return ResponseMessage(response);
    }
