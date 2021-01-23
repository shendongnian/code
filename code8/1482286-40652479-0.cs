    protected void Application_BeginRequest()
    {
        if (Request.ApplicationPath != "/" && Request.ApplicationPath.Equals(Request.Path, StringComparison.CurrentCultureIgnoreCase))
        {
            var redirectUrl = VirtualPathUtility.AppendTrailingSlash(Request.ApplicationPath);
            Response.RedirectPermanent(redirectUrl);
        }
    }
