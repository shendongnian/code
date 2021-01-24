    protected void Application_BeginRequest()
    {
    	if (Request.Headers.AllKeys.Contains("Origin", StringComparer.CurrentCultureIgnoreCase)
    		&& Request.HttpMethod == "OPTIONS")
    	{
    		Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control, Authorization ");
    		Response.End();
    	}
    }
