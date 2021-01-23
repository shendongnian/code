        static Dictionary<string, string> GetTokenDetails(string userName, string password)
        {
            Dictionary<string, string> tokenDetails = null;
            try
            {
                using (var client = new HttpClient())
                {
                    var login = new Dictionary<string, string>
                       {
                           {"grant_type", "password"},
                           {"username", userName},
                           {"password", password},
                       };
                    var resp = client.PostAsync("http://localhost:61086/token", new FormUrlEncodedContent(login));
                    resp.Wait(TimeSpan.FromSeconds(10));
                    if (resp.IsCompleted)
                    {
                        if (resp.Result.Content.ReadAsStringAsync().Result.Contains("access_token"))
                        {
                            tokenDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(resp.Result.Content.ReadAsStringAsync().Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return tokenDetails;
        }
