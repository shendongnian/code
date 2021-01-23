    private async Task<AuthResult> AuthenticateGoogleAsync()
        {
            try
            {
                var stateGuid = Guid.NewGuid().ToString();
                var expiration = DateTimeOffset.Now;
                var url = $"{GoogleAuthorizationEndpoint}?client_id={WebUtility.UrlEncode(GoogleAccountClientId)}&redirect_uri={WebUtility.UrlEncode(GoogleRedirectURI)}&state={stateGuid}&scope={WebUtility.UrlEncode(GoogleScopes)}&display=popup&response_type=code";
                var success = Windows.System.Launcher.LaunchUriAsync(new Uri(url));
                GoogleExternalAuthWait = new AsyncManualResetEvent<string>();
                var query = await GoogleExternalAuthWait.WaitAsync();
                var dictionary = query.Substring(1).Split('&').ToDictionary(x => x.Split('=')[0], x => Uri.UnescapeDataString(x.Split('=')[1]));
                if (dictionary.ContainsKey("error"))
                {
                    return null;
                }
                if (!dictionary.ContainsKey("code") || !dictionary.ContainsKey("state"))
                {
                    return null;
                }
                if (dictionary["state"] != stateGuid)
                    return null;
                string tokenRequestBody = $"code={dictionary["code"]}&redirect_uri={Uri.EscapeDataString(GoogleRedirectURI)}&client_id={GoogleAccountClientId}&access_type=offline&scope=&grant_type=authorization_code";
                StringContent content = new StringContent(tokenRequestBody, Encoding.UTF8, "application/x-www-form-urlencoded");
                // Performs the authorization code exchange.
                using (HttpClientHandler handler = new HttpClientHandler())
                {
                    handler.AllowAutoRedirect = true;
                    using (HttpClient client = new HttpClient(handler))
                    {
                        HttpResponseMessage response = await client.PostAsync(GoogleTokenEndpoint, content);
                        if (response.IsSuccessStatusCode)
                        {
                            
                            var stringResponse = await response.Content.ReadAsStringAsync();
                            var json = JObject.Parse(stringResponse);
                            var id = DecodeIdFromJWT((string)json["id_token"]);
                            var oauthToken = new AuthResult()
                            {
                                Provider = AccountType.Google,
                                AccessToken = (string)json["access_token"],
                                Expiration = DateTimeOffset.Now + TimeSpan.FromSeconds(int.Parse((string)json["expires_in"])),
                                Id = id,
                                IdToken = (string)json["id_token"],
                                ExpirationInSeconds = long.Parse((string)json["expires_in"]),
                                IssueDateTime = DateTime.Now,
                                RefreshToken = (string)json["refresh_token"]
                            };
                            return oauthToken;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
