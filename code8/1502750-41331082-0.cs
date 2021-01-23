    protected void Application_BeginRequest()
    {
        var context = HttpContext.Current;
        var response = context.Response;
        if (context.Request.HttpMethod == "OPTIONS")
        {
            response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
            response.End();
        }
    }
