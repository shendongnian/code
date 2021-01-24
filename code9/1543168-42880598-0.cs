    public static class ActionExtensions
    	{
    		public static bool ActionAuthorized(this HtmlHelper htmlHelper, string actionName, string controllerName)
    		{
    			ControllerBase controllerBase = string.IsNullOrEmpty(controllerName) ? htmlHelper.ViewContext.Controller : htmlHelper.GetControllerByName(controllerName);
    			ControllerContext controllerContext = new ControllerContext(htmlHelper.ViewContext.RequestContext, controllerBase);
    			ControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor(controllerContext.Controller.GetType());
    			ActionDescriptor actionDescriptor = controllerDescriptor.FindAction(controllerContext, actionName);
    
    			if (actionDescriptor == null)
    				return false;
    
    			FilterInfo filters = new FilterInfo(FilterProviders.Providers.GetFilters(controllerContext, actionDescriptor));
    
    			AuthorizationContext authorizationContext = new AuthorizationContext(controllerContext, actionDescriptor);
    			foreach (IAuthorizationFilter authorizationFilter in filters.AuthorizationFilters)
    			{
    				authorizationFilter.OnAuthorization(authorizationContext);
    				if (authorizationContext.Result != null)
    					return false;
    			}
    			return true;
    		}
    	}
