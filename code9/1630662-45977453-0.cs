    public async Task<string> GetAccessToken(string clientId, string redirectUri,string clientSecret, string authCode, string grantType)
            {
               
                var testData = new Data(){ClientId = clientId,
                    ClientSecret = clientSecret,              
                 RedirectUri = redirectUri,
                 GrantType = grantType,
                 Code = authCode
                };
                
                var uri = 
                    $"https://www.universe.com/oauth/token";
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    var str = JsonConvert.SerializeObject(testData);
                    var dataContent = new StringContent(str);
                    var response = await httpClient.PostAsync(uri, dataContent);
                    return await response.Content.ReadAsStringAsync();
                }
               
            }
            public class Data
            {
                [JsonProperty("code")]
                public string Code { get; set; }
                [JsonProperty("grant_type")]
                public string GrantType { get; set; }
                [JsonProperty("client_id")]
                public string ClientId { get; set; }
                [JsonProperty("client_secret")]
                public string ClientSecret { get; set; }
                [JsonProperty("redirect_uri")]
                public string RedirectUri { get; set; }
            }
