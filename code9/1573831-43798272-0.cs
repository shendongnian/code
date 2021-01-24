                string decoded = System.Web.HttpUtility.HtmlDecode(input);
                string encoded = System.Web.HttpUtility.HtmlEncode(input);
   
    // similar for URLs (like converting the space to plus sign, etc.)
                string urldecoded = System.Web.HttpUtility.UrlDecode(url);
                string urlencoded = System.Web.HttpUtility.UrlEncode(url);
