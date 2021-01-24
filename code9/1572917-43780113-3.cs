    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public sealed class NoCacheAttribute : ActionFilterAttribute
		{
		public override void OnResultExecuting(ResultExecutingContext filterContext)
			{
			filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
			filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
			filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
			filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			filterContext.HttpContext.Response.Cache.SetNoStore();
			//Added later from: https://stackoverflow.com/questions/49547/how-to-control-web-page-caching-across-all-browsers
			filterContext.HttpContext.Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
			filterContext.HttpContext.Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
			filterContext.HttpContext.Response.AppendHeader("Expires", "0"); // Proxies.
			
			base.OnResultExecuting(filterContext);
			}
		}
