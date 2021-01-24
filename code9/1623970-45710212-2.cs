    // Truncated CSP filter
    public class ContentSecurityPolicyFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpResponseBase response = filterContext.HttpContext.Response;
            response.AddHeader("Content-Security-Policy", "default-src *; img-src * data:; ");
            base.OnActionExecuting(filterContext);
        }
    }
    // Addition to FilterConfig.cs
    filters.Add(new ContentSecurityPolicyFilterAttribute());
