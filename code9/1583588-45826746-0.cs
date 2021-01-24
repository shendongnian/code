    private readonly HttpClient _client;
    public async Task<SsoResponse> AuthenticateAsync(string code)
            {
                if (string.IsNullOrEmpty(code))
                    throw new ArgumentNullException("Authentication code is null or empty");
    
                // Build the link to the SSO we will be using.
                var builder = new UriBuilder(_settings.BaseUrl)
                {
                    Path = _settings.TokenPath,
                    Query = $"grant_type=authorization_code&code={code}"
                };
    
                var request = new HttpRequestMessage()
                {
                    RequestUri = builder.Uri,
                    Method = HttpMethod.Post
                };
    
                // Set the necessary headers
                request.Headers.Add("Authorization", $"{TokenType.Basic} {_authorizationString}");
                request.Headers.Add("Host", builder.Host);
                request.Headers.Add("User-Agent", _userAgent);
    
                return await CallSsoAsync<SsoResponse>(request);
            }
    private async Task<T> CallSsoAsync<T>(HttpRequestMessage request)
            {
                T response = default(T);
                using (HttpResponseMessage resp = await _client.SendAsync(request))
                {
                    // Check whether the SSO answered with 
                    // a positive HTTP Status Code
                    if (resp.IsSuccessStatusCode)
                    {
                        // Deserialize the object into the response model
                        // which will be returned to the application
                        response = JsonConvert.DeserializeObject<T>(await resp.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        // Invalid code receieved, inform the user
                        throw new Exception("The SSO responded with a bad status code: " + resp.StatusCode);
                    }
                }
    
                return response;
            }
