    private static async Task<string> GetTestSamlResponse()
        {
            try
            {
                // settings specific to my Okta instance
                string username = "USERNAME GOES HERE";
                string password = "PASSWORD GOES HERE";
                var apiToken = "API TOKEN GOES HERE";
                // this is the unique domain issued to your account.  
                // If you setup a dev account you'll have a domain in the form https://dev-<AccountNumber>.oktapreview.com.
                // account number is a unique number issues by Okta when you sign up for the account
                var baseUrl = "YOUR BASE URL GOES HERE";
                // In Okta Admin UI, click "Applications" in main menu, choose your app, click "Sign On" tab.  Under Sign On Methods, then under SAML 2.0, click "View Setup Instructions"
                // Get the url called "Identity Provider Single Sign-On URL", paste it in th below line
                var ssoUrl = "YOUR SSO URL GOES HERE";
                // construct an Okta settings object
                var settings = new Okta.Core.OktaSettings
                {
                    ApiToken = apiToken,
                    BaseUri = new Uri(baseUrl)
                };
                // get session token from Okta
                var authClient = new Okta.Core.Clients.AuthClient(settings);
                var authResponse = authClient.Authenticate(username, password);
                var sessionToken = authResponse.SessionToken;
                // start session and get a cookie token
                var sessionsClient = new Okta.Core.Clients.SessionsClient(settings);
                var session = sessionsClient.CreateSession(sessionToken);
                var cookieToken = session.CookieToken;
                // using the cookie token, get the SAMLResponse from Okta via a HTTP GET.
                var httpClient = new System.Net.Http.HttpClient();
                // add User-Agent header, because apparently Okta is expecting this information.  
                // If you don't pass something, the Okta site will return a 500 - Internal Server error
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "UnitTest");
                // add the cookie token to the URL query string
                string url = string.Format("{0}?onetimetoken={1}", ssoUrl, cookieToken);
                // do the HTTP GET
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        // read the HTML returned
                        string html = await response.Content.ReadAsStringAsync();
                        // parse the HTML to get the SAMLResponse (using HtmlAgilityPack from NuGet)
                        HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                        htmlDoc.LoadHtml(html);
                        // from the input field called SAMLResponse, get the "value" attribute
                        string samlResponse = htmlDoc.DocumentNode.SelectSingleNode("//input[@name='SAMLResponse']").Attributes["value"].Value;
                        return samlResponse;
                    }
                    else
                        throw new Exception(string.Format("Error getting SAML Response {0}", response.StatusCode));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
