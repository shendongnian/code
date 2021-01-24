    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
    	try
    	{
    		if (Request.Url != null)
    		{
    			var queryUrl = Request.Url.Query;
    			if (queryUrl.Contains("%26") || queryUrl.Contains("%3"))
    			{
    				var routeValueDictionary = new RouteValueDictionary
    				{
    					{"controller", "Error"},
    					{"action", "Index"}
    				};
    				filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(routeValueDictionary));
    			}
    		}
    	}
    	catch (HttpRequestValidationException exception)
    	{
    		var routeValueDictionary = new RouteValueDictionary { { "controller", "Error" }, { "action", "Index" } };
    		filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(routeValueDictionary));
    	}
    }
