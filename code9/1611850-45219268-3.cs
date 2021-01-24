    public IHttpActionResult Get()
    {
        var jsonResult = new StringBuilder();
        /// get JSON
        var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        response.Content = new StringContent(jsonResult.ToString());
        return ResponseMessage(response);
    }
