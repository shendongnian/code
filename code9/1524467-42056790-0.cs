    protected void Application_BeginRequest(object sender, EventArgs e)
    {
            
            var HOST = "test.com";
            if ( ( !Request.ServerVariables["HTTP_HOST"].Equals(
              HOST,
              StringComparison.InvariantCultureIgnoreCase ) 
             ||  ( !HttpContext.Current.Request.IsSecureConnection ) )
            {
                Response.RedirectPermanent(
                  ("https://"  
                  + HOST
                  + HttpContext.Current.Request.RawUrl);
                 //RawUrl means any url information after the domain
            }
    }
