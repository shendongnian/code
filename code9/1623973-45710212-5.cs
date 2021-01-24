    public class ContentSecurityPolicyFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpResponseBase response = filterContext.HttpContext.Response;
            var header = response.Headers["Content-Security-Policy"];
            if (header == null)
            {
                response.AddHeader("Content-Security-Policy", "default-src *; img-src * data:; ");
            }
            base.OnActionExecuting(filterContext);
        }
    }
