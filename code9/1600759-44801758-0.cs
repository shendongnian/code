    protected void Application_BeginRequest(Object source, EventArgs e)
    {
      if (!Context.Request.IsSecureConnection)
      {
          Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
      }
    }
