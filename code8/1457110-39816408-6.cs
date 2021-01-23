    using ActionFilterAttribute 
	using System.Web.Mvc;
	namespace site_redesign_web.Filters
	{
		public class SystemAdminFilter : ActionFilterAttribute
		{
			string SysAdminRole = "System Administrator";
			public override void OnActionExecuting(ActionExecutingContext filterContext)
			{
				if (filterContext.RequestContext.HttpContext.User != null)
				{
					var userSysAdmin = filterContext.RequestContext.HttpContext.User.IsInRole(SysAdminRole) == true;
					
				if(!userSysAdmin)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary{
                        {"controller", "Home"},     
                        {"action", "Index"}
                    });
                }
				}
			}
		}
	}
