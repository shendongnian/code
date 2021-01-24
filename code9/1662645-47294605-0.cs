    public HttpResponseMessage GetObject()
    {
        string json = GetJsonFromDatabase();
        if (!string.IsNullOrEmpty(json))
        {
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }
        throw new HttpResponseException(HttpStatusCode.NotFound);
    }
