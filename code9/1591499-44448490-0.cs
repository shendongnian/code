    public class TenantActionFilterAttribute : ActionFilterAttribute
    {
        internal const string _Tenant = "tenant";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Do this how ever you want, right now I'm using querystring
            // Could be changed to use DNS name or whatever
            var tenant = filterContext.HttpContext.Request.QueryString[_Tenant] as string;
            if (tenant != null)
            {
                filterContext.RouteData.Values[Tenant] = tenant;
            }
        }
    }
