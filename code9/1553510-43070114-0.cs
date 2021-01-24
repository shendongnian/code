    [HttpGet]
    public async Task<IActionResult> Login() {
        var httpClientHandler = new HttpClientHandler();
        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
        var client = new HttpClient(httpClientHandler);
        client.Timeout = TimeSpan.FromSeconds(90);
        var request = new HttpRequestMessage(HttpMethod.Post, myUrl);
        request.Content = new StringContent(myXmlString, Encoding.UTF8, "text/xml");
        request.Headers.Add("SOAPAction", https://actionNameOfWs);
        var response = await client.SendAsync(request);
        if(response.StatusCode == HttpStatusCode.OK) return Ok();
        else return StatusCode((int)response.StatusCode);
    }
