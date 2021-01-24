    protected override string QueryAccessToken(Uri returnUrl, string authorizationCode)
        {
            var uri = BuildUri(TokenEndpoint, new NameValueCollection
                {
                    { "code", authorizationCode },
                    { "client_id", _appId },
                    { "client_secret", _appSecret },
                    { "redirect_uri", returnUrl.GetLeftPart(UriPartial.Path) },
                });
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            string accessToken = null;            
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            // handle response from FB 
            // this will not be a url with params like the first request to get the 'code'
            Encoding rEncoding = Encoding.GetEncoding(response.CharacterSet);
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), rEncoding))
            {
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                var jsonObject = serializer.DeserializeObject(sr.ReadToEnd());
                var jConvert = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(jsonObject));
                Dictionary<string, object> desirializedJsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(jConvert.ToString());
                accessToken = desirializedJsonObject["access_token"].ToString();
            }
            return accessToken;
        }
