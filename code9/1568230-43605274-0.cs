    protected void Application_BeginRequest() {
               // Ensure any request is returned over SSL/TLS in production
               if (!Request.IsLocal && !Context.Request.IsSecureConnection) {
                   var redirect = Context.Request.Url.ToString().ToLower(CultureInfo.CurrentCulture).Replace("http:", "https:");
                   Response.Redirect(redirect);
               }
    }
