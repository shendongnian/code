    protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
    {
        HttpApplication app = sender as HttpApplication;
        if (app != null &&
            app.Context != null)
        {
            app.Context.Response.Headers.Remove("Server");
        }
    }
