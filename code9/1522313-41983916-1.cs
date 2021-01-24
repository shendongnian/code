    public async Task<string> SomeMethodAsync() {
        try {
            var clientCredential = new ClientCredential(_clientId, _clientSecret);
            var authContext = new AuthenticationContext(AuthUri + _tenant);
            var authResult = await authContext.AcquireTokenAsync(GraphUri,clientCredential);
            var authString = authResult.CreateAuthorizationHeader();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
            var request = new HttpRequestMessage {
                Method = HttpMethod.Get,
                RequestUri = _requestUri,
            };
            request.Headers.Add("Authorization", authString);
            
            using(var response = await client.SendAsync(request)) {
                return await response.Content.ReadAsStringAsync();
            }    
        } catch (Exception ex) {
           Console.WriteLine(ex);
        }
    }
