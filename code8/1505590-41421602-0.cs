    System.Text.StringBuilder sbMetaDetails = new System.Text.StringBuilder();
    
    string urlReferer;
    string pageURL=null;
    if (HttpContext.Current.Request.UrlReferrer != null)
    {
        pageURL = Request.QueryString["pageurl"] + "#lg=1&slide=" + Request.QueryString["slide"];
        .....
        .....
        .....
    }
