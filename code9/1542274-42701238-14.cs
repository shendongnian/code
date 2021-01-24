    protected void Application_BeginRequest(object sender, EventArgs e)
    {
    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin",    "http://localhost");
    if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
    {
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, PUT, DELETE");
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
        HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
        HttpContext.Current.Response.End();
    }
    }
