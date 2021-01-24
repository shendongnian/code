    /// <summary>
        /// Return User informations as a JObject. To get username and email, if return isn't null :
        /// username = json["name"].ToString();
        /// email = json["emails"]["account"].ToString();
        /// </summary>
        /// <param name="accessToken">accesstoken of Onedrive account</param>
        /// <returns>JObject value</returns>
        public static async Task<JObject> GetUserInfos(string accessToken)
        {
            JObject json = null;
            Uri uri = new Uri($"https://apis.live.net/v5.0/me?access_token={accessToken}");
            System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage result = await httpClient.GetAsync(uri);
            //user info returnd as JSON
            string jsonUserInfo = await result.Content.ReadAsStringAsync();
            if (jsonUserInfo != null)
            {
                json = JObject.Parse(jsonUserInfo);
                //username = json["name"].ToString();
                //email = json["emails"]["account"].ToString();
            }
            return json;
        }
