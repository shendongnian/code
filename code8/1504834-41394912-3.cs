    void Application_PostAcquireRequestState(object sender, EventArgs e)
    {
        HttpContext context = ((HttpApplication)sender).Context;
        if (context.Session != null)
        {
            if (context.Session["sessionExist"] is bool && (bool)context.Session["sessionExist"])
                return;
        }
        FormsAuthentication.SignOut();
    }
