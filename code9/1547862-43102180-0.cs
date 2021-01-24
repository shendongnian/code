        private async Task<string> GetAccessToken()
        {
            string pBiUser = Properties.Settings.Default.PowerBIUser;
            string pBiPwd = Properties.Settings.Default.PowerBIPwd;
            string pBiClientId = Properties.Settings.Default.PowerBIClientId;
            string pBiSecret = Properties.Settings.Default.PowerBIClientSecret;
            string pBITenant = Properties.Settings.Default.PowerBITenantId;
            string tokenEndpointUri = "https://login.microsoftonline.com/"+pBITenant+"/oauth2/token";
            var content = new FormUrlEncodedContent(new[]
                {
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("username", pBiUser),
            new KeyValuePair<string, string>("password", pBiPwd),
            new KeyValuePair<string, string>("client_id", pBiClientId),
            new KeyValuePair<string, string>("client_secret", pBiSecret),
            new KeyValuePair<string, string>("resource", "https://analysis.windows.net/powerbi/api")
            });
            using (var client = new HttpClient())
            {
                HttpResponseMessage res = client.PostAsync(tokenEndpointUri, content).Result;
                string json = await res.Content.ReadAsStringAsync();
                AzureAdTokenResponse tokenRes = JsonConvert.DeserializeObject<AzureAdTokenResponse>(json);
                return tokenRes.AccessToken;
            }
        }
