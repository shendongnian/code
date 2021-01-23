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
					//below line is modified so that it is marked that the User is unauthorized
					filterContext.Result = new HttpUnauthorizedResult(); 
				}
			}
			public override void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
			{
				if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
				{
					//redirects to Home Controller and Index action
					filterContext.Result = new RedirectToRouteResult(
						new System.Web.Routing.RouteValueDictionary{
							{"controller", "Home"},		
							{"action", "Index"}
						});
				}
			}
		}
	}
