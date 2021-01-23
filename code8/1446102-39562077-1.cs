            private async Task<string> SendGraphPostRequest(string api, string json)
        {
            // NOTE: This client uses ADAL v2, not ADAL v4
            var result = authContext.AcquireToken(Globals.aadGraphResourceId, credential);
            var http = new HttpClient();
            var url = Globals.aadGraphEndpoint + tenant + api + "?" + Globals.aadGraphVersion;
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await http.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                var formatted = JsonConvert.DeserializeObject(error);
                //Console.WriteLine("Error Calling the Graph API: \n" + JsonConvert.SerializeObject(formatted, Formatting.Indented));
                Logger.Error("Error Calling the Graph API: \n" + JsonConvert.SerializeObject(formatted, Formatting.Indented));
            }
            Logger.Info((int)response.StatusCode + ": " + response.ReasonPhrase);
            return await response.Content.ReadAsStringAsync();
        }
