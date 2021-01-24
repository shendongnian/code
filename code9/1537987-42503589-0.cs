    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class LocalHostOnlyAttribute : Attribute, IAuthorizationFilter
    {
        [Authorize]
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // restrict if hostname is not localhost.
            if(context.HttpContext.Request.Host.Host !="localhost"){
                // return UnauthorizedAccess razor page/view if not allowed.
                context.Result = new ViewResult() {ViewName = "UnauthorizedAccess" };
            }
        }
    }
