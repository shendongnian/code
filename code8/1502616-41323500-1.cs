    protected void Page_Load(object sender, EventArgs e)
    {
        var text = "";
        if (IsPostBack)
        {
            text = Request.Form["txtFirstName"];
        }
    
        string jsonString;
    
        using (var webClient = new System.Net.WebClient())
        {
            jsonString = webClient.DownloadString(text);
        }
    
        if (string.IsNullOrWhiteSpace(jsonString))
        {
            // Nothing to do so we return
            return;
        }
    
    
        ProductsJsonModel Data = JsonConvert.DeserializeObject<ProductsJsonModel>(jsonString);
        List<Product> ProductsFromUrl = Data.products; // All of your products are here.
    
        // Your code
        // All the products are in the value session variable so we can get it later
        Session["value"] = ProductsFromUrl;
    
        var oauth_consumer_key = "myLtWOTLGtLsjNsm15tUUpdEX";
        var oauth_consumer_secret = "uC9yHjPPV83Olvq0I8zt9eMwyucIpUcO70NduqNx0JuPQVyDZB";
    
        if (Request["oauth_token"] == null)
        {
            OAuthTokenResponse reqToken = OAuthUtility.GetRequestToken(
                oauth_consumer_key,
                oauth_consumer_secret,
                Request.Url.AbsoluteUri);
    
            Response.Redirect(string.Format("http://twitter.com/oauth/authorize?oauth_token={0}",
                reqToken.Token));
    
        }
        else
        {
            string requestToken = Request["oauth_token"].ToString();
            string pin = Request["oauth_verifier"].ToString();
    
            var tokens = OAuthUtility.GetAccessToken(
                oauth_consumer_key,
                oauth_consumer_secret,
                requestToken,
                pin);
    
            OAuthTokens accesstoken = new OAuthTokens()
            {
                AccessToken = tokens.Token,
                AccessTokenSecret = tokens.TokenSecret,
                ConsumerKey = oauth_consumer_key,
                ConsumerSecret = oauth_consumer_secret
            };
    
            //TwitterResponse<TwitterStatus> response = TwitterStatus.Update(
            //    accesstoken,
            //    "Testing!! It works (hopefully).");
    
            var prods = Session["value"];
            if (prods != null)
            {
                ProductsFromUrl = Session["value"] as List<Product>;
    
                var title = "";
                var cnt = ProductsFromUrl.Count;
    
                for (int i = 0; i < cnt; i++)
                {
                    title = ProductsFromUrl[0].title;
    
                }
                Twitterizer.TwitterResponse<TwitterStatus> response =
                    TwitterStatus.Update(accesstoken, title, new StatusUpdateOptions()
                    { UseSSL = true, APIBaseAddress = "http://api.twitter.com/1.1/" });
    
                if (response.Result == RequestResult.Success)
                {
                    Response.Redirect("https://twitter.com/");
                }
                else
                {
                    Response.Redirect("https://twitter.com/");
                }
    
                // clear the session
                Session.Remove("value");
            }
                   
        }
    }
