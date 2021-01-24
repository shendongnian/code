    public class SocialAuthService
        {
            private SocialConfig SocialConfig { get; set; }
    
            public SocialAuthService(SocialConfig socialConfig)
            {
                SocialConfig = socialConfig;
            }
    
            public async Task<User> VerifyTokenAsync(ExternalToken exteralToken)
            {
                switch (exteralToken.Provider)
                {
                    case "Facebook":
                        return await VerifyFacebookTokenAsync(exteralToken.Token);
                    default:
                        return null;
                }
            }
    
            private async Task<User> VerifyFacebookTokenAsync(string token)
            {
                var user = new User();
                var client = new HttpClient();
    
                var verifyTokenEndPoint = string.Format("https://graph.facebook.com/me?access_token={0}&fields=email,name", token);
                var verifyAppEndpoint = string.Format("https://graph.facebook.com/app?access_token={0}", token);
    
                var uri = new Uri(verifyTokenEndPoint);
                var response = await client.GetAsync(uri);
    
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic userObj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);
    
                    uri = new Uri(verifyAppEndpoint);
                    response = await client.GetAsync(uri);
                    content = await response.Content.ReadAsStringAsync();
                    dynamic appObj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);
    
                    if (appObj["id"] == SocialConfig.Facebook.AppId)
                    {
                        //token is from our App
                        user.SocialUserId = userObj["id"];
                        user.Email = userObj["email"];
                        user.Name = userObj["name"];
                        user.IsVerified = true;
                    }
    
                    return user;
                }
                return user;
            }
        }
