    public class AuditAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            // get user name + ip address + controlleraction 
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = filterContext.ActionDescriptor.ActionName;
            var ip = filterContext.HttpContext.Request.UserHostAddress;
            var dateTime = filterContext.HttpContext.Timestamp;
            var user = GetUserName(filterContext.HttpContext);
        }
        
            
        private string GetUserName(HttpContext httpContext)
        {
            var userName = string.Empty;
            var context = httpContext.Current;
            if (context != null && context.User != null && context.User.Identity.IsAuthenticated)
            {
                userName = context.User.Identity.Name;
            }
            else
            {
                var threadPincipal = Thread.CurrentPrincipal;
                if (threadPincipal != null && threadPincipal.Identity.IsAuthenticated)
                {
                    userName = threadPincipal.Identity.Name;
                }
            }
            return userName;
        }
    }
