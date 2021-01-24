                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
    
                HttpContent content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"client_id", _clientId},
                    {"client_secret", _clientSecret},
                    {"username", _userName},
                    {"password", _password}
                }
                    );
    
                    using (var httpClient = new HttpClient())
                    {
                        var message =
                            await httpClient.PostAsync(_authorizationUrl, content).ConfigureAwait(false);
                        var responseString = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
    
                        var obj = JObject.Parse(responseString);
    
                        var oauthToken = (string)obj["access_token"];
                        var serviceUrl = (string)obj["instance_url"];
    }
