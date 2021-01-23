    System.Text.StringBuilder sbMetaDetails = new System.Text.StringBuilder();
    
    string urlReferer;
    string pageURL=null;
    if (HttpContext.Current.Request.UrlReferrer != null)
    {
        pageURL = HttpContext.Current.Request.QueryString["pageurl"] + "#lg=1&slide=" + HttpContext.Current.Request.QueryString["slide"];
        .....
        .....
        .....
    }
