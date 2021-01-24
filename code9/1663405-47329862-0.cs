    var authentication = new OfficeDevPnP.Core.AuthenticationManager();
    context = authentication.GetWebLoginClientContext(siteUrl);
    webClient = new WebClient();
    context.ExecutingWebRequest += StealCookieOnExecutingWebRequest;
    void StealCookieOnExecutingWebRequest(object sender, WebRequestEventArgs e)
    {
        var cookies = e.WebRequestExecutor.WebRequest.CookieContainer;
        webClient.Headers[HttpRequestHeader.Cookie] = cookies.GetCookieHeader(new Uri(SiteUrl));
        context.ExecutingWebRequest -= StealCookieOnExecutingWebRequest;
    }
    
