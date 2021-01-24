            protected void Page_Load(object sender, EventArgs e)
            {
                if (Request.Params["code"] != null)
                {
                    var accesstoken = AcquireTokenWithResource(resource: "https://graph.microsoft.com/");
    
                    Response.Write(accesstoken);
                }
            }
    
    
            protected void Button2_Click(object sender, EventArgs e)
            {
                GetAuthorizationCode();
            }
    
            public void GetAuthorizationCode()
            {
                JObject response = new JObject();
    
                var parameters = new Dictionary<string, string>
                    {
                        { "response_type", "code" },
                        { "client_id", "clientid" },
                        { "redirect_uri", "http://localhost:8099/WebForm1.aspx" },
                        { "prompt", "login"},
                        { "scope", "openid"}
                    };
    
                var requestUrl = string.Format("{0}/authorize?{1}", EndPointUrl, BuildQueryString(parameters));
    
                Response.Redirect(requestUrl);
    
            }
            public string AcquireTokenWithResource(string resource)
            {
                var code = Request.Params["code"];
                AuthenticationContext ac =
            new AuthenticationContext(string.Format("https://login.microsoftonline.com/{0}", "tenantID"
                                      ));
                ClientCredential clcred =
                    new ClientCredential("clientID", "clientSecret");
                var token =
                    ac.AcquireTokenByAuthorizationCodeAsync(code,
                               new Uri("http://localhost:8099/WebForm1.aspx"), clcred,resource).Result.AccessToken;
    
                return token;
            }
            private string BuildQueryString(IDictionary<string, string> parameters)
            {
                var list = new List<string>();
    
                foreach (var parameter in parameters)
                {
                    list.Add(string.Format("{0}={1}", parameter.Key, HttpUtility.UrlEncode(parameter.Value)));
                }
    
                return string.Join("&", list);
            }
    
            protected string EndPointUrl
            {
                get
                {
                    return string.Format("{0}/{1}/{2}", "https://login.microsoftonline.com", "tenantID", @"oauth2/");
                }
            }
