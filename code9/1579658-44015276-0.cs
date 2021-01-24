    public async Task<IHttpActionResult> Get()
    {
        var query = Request.RequestUri.PathAndQuery;
        var client = new HttpClient();
        var crmEndPoint = @"HTTPS://MYCRMORG.COM/API/DATA/V8.1/";
        HttpResponseMessage response = await client.GetAsync(crmEndPoint + query);
        object result;
        if (response.IsSuccessStatusCode)
        {
            result = await response.Content.ReadAsAsync<object>();
            return Ok(result);
        }
        return NotFound();
    }
