    public ActionResult AccessToken()
    {
            // Step 1 - Retrieve an OAuth Request Token
            TwitterService service = new TwitterService(ConfigurationManager.AppSettings["TwitterConsumerKey"], ConfigurationManager.AppSettings["TwitterConsumerSecret"]);
            // This is the registered callback URL
            OAuthRequestToken requestToken = service.GetRequestToken("http://localhost:37808/Twitter/OToken");
            // Step 2 - Redirect to the OAuth Authorization URL
            Uri uri = service.GetAuthorizationUri(requestToken);
            return new RedirectResult(uri.ToString(), false /*permanent*/);
            //return View();
    }
    public ActionResult OToken()
    {
            return View();
    }
    public ActionResult UserInfo(string oauth_token, string oauth_verifier)
    {
            var requestToken = new OAuthRequestToken { Token = oauth_token };
            // Step 3 - Exchange the Request Token for an Access Token
            TwitterService service = new TwitterService(ConfigurationManager.AppSettings["TwitterConsumerKey"], 
                                                        ConfigurationManager.AppSettings["TwitterConsumerSecret"]);
            OAuthAccessToken accessToken = service.GetAccessToken(requestToken, oauth_verifier);
            // Step 4 - User authenticates using the Access Token
            service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
            TwitterUser user = service.VerifyCredentials(new VerifyCredentialsOptions());
            ViewBag.Message = string.Format("{0}", user.ScreenName);
            // Step 5 - Send Tweet to User TimeLine
            SendTweetOptions options = new SendTweetOptions();
            string URL = "file:\\C:\\Users\\<User>\\Desktop\\test.jpg";
            string path = new Uri(URL).LocalPath;        
            // Sending with Media
            using (var stream = new FileStream(path, FileMode.Open))
            {
                service.SendTweetWithMedia(new SendTweetWithMediaOptions
                {
                    Status = "<status>",
                    Images = new Dictionary<string, Stream> { { path, stream } }
                });
            }
            var responseText = service.Response.StatusCode;
            if (responseText.ToString() == "OK")
            {
                ViewBag.Message = "Tweet Successful";
            }
            else
            {
                ViewBag.Message = "Tweet Unsuccessful";
            }            
            return View();
        }                                      
    }
