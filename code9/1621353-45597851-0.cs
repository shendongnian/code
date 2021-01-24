    [HttpGet]
    [Route("account({accountid})/printgroup", Name = "Get")]
    public async Task<IHttpActionResult> Get(int accountid) {
        var query = Request.RequestUri.Query;
        var uri = new Uri(Client.Instance.BaseAddress.ToString().Replace("[accountid]", accountid.ToString()) + query);
        var request = new HttpRequestMessage { RequestUri = uri, Method = HttpMethod.Get };
        var clientResponse = await Client.Instance.SendAsync(request);
        if (clientResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound();
        return ResponseMessage(clientResponse);
    }
