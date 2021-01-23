    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class VerifyPasswordChangedAttribute : ActionFilterAttribute
    {
    	public override void OnActionExecuting(ActionExecutingContext filterContext)
    	{
    		if(!filterContext.ActionDescriptor.ActionName.Equals("changepassword", StringComparison.OrdinalIgnoreCase))
    		{
    			if (filterContext.HttpContext.Request.IsAuthenticated)
    			{
    				var userName = filterContext.HttpContext.User.Identity.Name;
    				
    				PasswordChangeChecker PassCheck = new PasswordChangeChecker();
    				
    				if (!PassCheck.IsPasswordChangedFromInitial(userName))
    				{
    					filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "account", action = "changepassword", area = string.Empty }));
    				}
    			}
    		}
    		
    		base.OnActionExecuting(filterContext);
    	}
    }
