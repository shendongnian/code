    public async Task<string> CreateUser(string accessToken)
        {
            string jsondata = File.ReadAllText(@"C:\\usertemplate-email.json");
            string endpoint = "https://graph.microsoft.com/v1.0/users";
            using (var client = new HttpClient())
            {
                var method = new HttpMethod("POST");
                using (var request = new HttpRequestMessage(method, endpoint))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    request.Content = new StringContent(jsondata.ToString(), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            //Status Code: 400, Reason Phrase:Bad Request
                            //On success, it gives Created
                            var json = JObject.Parse(await response.Content.ReadAsStringAsync());
                        }
                        return response.ReasonPhrase;
                    }
                }
            }
        }
