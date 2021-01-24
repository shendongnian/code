    public class ContentSecurityPolicyFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.RequestContext.HttpContext.Items.Contains(nameof(ContentSecurityPolicyFilterAttribute)))
            {
                HttpResponseBase response = filterContext.HttpContext.Response;
                response.AddHeader("Content-Security-Policy", "default-src *; img-src * data:; ");
                filterContext.RequestContext.HttpContext.Items.Add(nameof(ContentSecurityPolicyFilterAttribute), string.Empty);
            }
            base.OnActionExecuting(filterContext);
        }
    }
