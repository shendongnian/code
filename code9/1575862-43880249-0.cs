    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class RedirectAttribute:ActionFilterAttribute
    {
    	public override void OnActionExecuted(ActionExecutedContext filterContext)
    	{
    		if(filterContext.Controller.ControllerContext.RouteData.Values.ContainsValue("Foo"))
    		{
    			//Redirect to the login for example
    			UrlHelper urlHelper = new UrlHelper(filterContext.HttpContext.Request.RequestContext);
    			string url = urlHelper.Action("actionName", "controllerName");
    			filterContext.Result = new RedirectResult(redirectUrl);
    		}
    	}
    }
