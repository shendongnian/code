    // Set cookies here
    var cookieUrl = new Uri(AppInfo.URL_BASE);
    var cookieJar = NSHttpCookieStorage.SharedStorage;
    cookieJar.AcceptPolicy = NSHttpCookieAcceptPolicy.Always;
    foreach (var aCookie in cookieJar.Cookies)
    {
        cookieJar.DeleteCookie(aCookie);
    }
    var jCookies = UserInfo.CookieContainer.GetCookies(cookieUrl);
    IList<NSHttpCookie> eCookies = 
                       (from object jCookie in jCookies 
                        where jCookie != null 
                        select (Cookie) jCookie 
                        into netCookie select new NSHttpCookie(netCookie)).ToList();
    cookieJar.SetCookies(eCookies.ToArray(), cookieUrl, cookieUrl);
