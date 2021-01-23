    [HttpGet, Route("{id}/overview/")]
     public async Task<HttpResponseMessage> Overview(string id, [FromUri]DateTime from, [FromUri]DateTime? to)
    {
    ...
    }
