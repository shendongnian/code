    public class LogInRequiredFilter : IAuthorizationFilter 
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!AttributeManager.HasAttribute(context, typeof(LogInRequired))) return;
            if (context.HttpContext.User.Identity.IsAuthenticated) return;
                
            context.Result = new RedirectResult("/login?ReturnUrl=" + Uri.EscapeDataString(context.HttpContext.Request.Path));
        }
    }
    public class LogInRequired : Attribute
    {
        public LogInRequired()
        {
        }
    }
