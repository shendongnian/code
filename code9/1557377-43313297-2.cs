    public async Task CallAPIAsync() {    
        using (var client = new HttpClient()) {
            var sessionId = Browser.Driver.GetSessionId();
            var uri = new Uri($"https://saucelabs.com/rest/v1/{Configuration.SauceUserName}/jobs/{sessionId}");
            var uriWithCred =
                new UriBuilder(uri) {
                    UserName = $"{Configuration.SauceUserName}",
                    Password = $"{Configuration.SauceAccessKey}"
                }.Uri;
            var payload = new StringContent($"{{\"name\":\"{TestMethodName}\"}}", Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage {
                Method = HttpMethod.Put,
                RequestUri = uriWithCred,
                Content = payload
            };
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
        }
    }
