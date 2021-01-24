    var cookieManager = CookieManager.Instance;
    cookieManager.SetAcceptCookie(true);
    cookieManager.RemoveAllCookie();
    var cookies = UserInfo.CookieContainer.GetCookies(new System.Uri(AppInfo.URL_BASE));
    for (var i = 0; i < cookies.Count; i++)
    {
        string cookieValue = cookies[i].Value;
        string cookieDomain = cookies[i].Domain;
        string cookieName = cookies[i].Name;
        cookieManager.SetCookie(cookieDomain, cookieName + "=" + cookieValue);
    }
