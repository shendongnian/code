    HeaderModOutputCacheProvider.RequestServedFromCache += RequestServedFromCache;
    
    HeaderModOutputCacheProvider.RequestServedFromCache += (sender, e) =>
    {
        e.AddCookies(new HttpCookieCollection
        {
            new HttpCookie("key", "value")
        });
    };
