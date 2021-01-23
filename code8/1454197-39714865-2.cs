    protected void Application_Error(object sender, EventArgs e)
    {
    	var exception = Server.GetLastError();
    
    	// Process 404 HTTP errors
    	var httpException = exception as HttpException;
    	if (httpException != null && httpException.GetHttpCode() == 404)
    	{
    		Response.Clear();
    		Server.ClearError();
    		Response.TrySkipIisCustomErrors = true;
    
    		// Call target Controller and pass the routeData.
    		IController controller = new CommonController();
    
    		var routeData = new RouteData();
    		routeData.Values.Add("controller", "Common");
    		routeData.Values.Add("action", "PageNotFound");
    
    		var requestContext = new RequestContext(
                 new HttpContextWrapper(Context), routeData);
    		controller.Execute(requestContext);
    	}
    }
