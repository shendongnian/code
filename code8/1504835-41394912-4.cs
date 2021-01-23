    void Application_PostAcquireRequestState(object sender, EventArgs e)
    {
        HttpContext context = ((HttpApplication)sender).Context;
        if (context.Session != null)
        {
            if (context.Session["sessionExist"] is bool && (bool)context.Session["sessionExist"])
                return;
        }
        // put code here that you want to execute if the session has expired
        // for example:
        FormsAuthentication.SignOut();
        // or maybe
        context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
    }
