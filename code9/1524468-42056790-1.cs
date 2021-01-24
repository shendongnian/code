    protected void Application_BeginRequest(object sender, EventArgs e)
    {
            #if !DEBUG
            string HTTPhost = Request.ServerVariables["HTTP_HOST"];
            string domainName = "test";
            //assuming that the app will only be reached via .COM or .NET
            string topLevel = HTTPhost.Split('.').LastOrDefault();
            //compare to make sure it only matches the root name with no trailing subdomain
            //or to redirect to secure url if unsecured
            if ( (!HTTPhost.Split('.').FirstOrDefault().Equals(domainName, StringComparison.InvariantCultureIgnoreCase) )
             || (!HttpContext.Current.Request.IsSecureConnection))
            {
                Response.RedirectPermanent(
                  "https://"
                  + domainName
                  + '.'
                  + topLevel
                  + HttpContext.Current.Request.RawUrl);
                //RawUrl means any url information after the domain
            }
           #endif
    }
