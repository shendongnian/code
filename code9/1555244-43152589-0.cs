    private void WebViewControl2_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
    {
        Uri gotouri = args.Uri;
        HttpBaseProtocolFilter myFilter = new HttpBaseProtocolFilter();
        HttpCookieManager cookieManager = myFilter.CookieManager;
        HttpCookieCollection myCookieJar = cookieManager.GetCookies(gotouri);
        foreach (HttpCookie cookie in myCookieJar)
        {
            cookieManager.DeleteCookie(cookie);
        }
    }
