    public async Task<HttpResponseMessage> GetOpportunity(HttpRequestMessage Request) {
        //at the line below is where i want to send the same headers that were passed in originally at step 1
        var query = Request.RequestUri.AbsolutePath.Split('/').Last() + Request.RequestUri.Query;
        var headers = Request.Headers;
        var url = Client.Instance.BaseAddress + query;
        //create new request and copy headers
        var proxy = new HttpRequestMessage(HttpMethod.Get, url);
        foreach (var header in headers) {
            proxy.Headers.Add(header.Key, header.Value);
        }
        var response = await Client.Instance.SendAsync(proxy);//This is an assumption.
        var responseType = response.StatusCode; //Do not mix blocking calls. It can deadlock
        if (responseType == HttpStatusCode.NotFound)
            return new HttpResponseMessage {
                StatusCode = responseType
            };
        return response;
    }
