    public class AuditAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                var context = actionContext.RequestContext;
                var user = context.Principal.Identity.IsAuthenticated ? context.Principal.Identity.Name : string.Empty;
                var ip = GetClientIpAddress(actionContext.Request);
                var action = actionContext.ActionDescriptor.ActionName;
                var controller = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
    
                base.OnActionExecuting(actionContext);
            }
    
            private string GetClientIpAddress(HttpRequestMessage request)
            {
                if (request.Properties.ContainsKey("MS_HttpContext"))
                {
                    return IPAddress.Parse(((HttpContextBase)request.Properties["MS_HttpContext"]).Request.UserHostAddress).ToString();
                }
                if (request.Properties.ContainsKey("MS_OwinContext"))
                {
                    return IPAddress.Parse(((OwinContext)request.Properties["MS_OwinContext"]).Request.RemoteIpAddress).ToString();
                }
                return String.Empty;
            }
    
        }
