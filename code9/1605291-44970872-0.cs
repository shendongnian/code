    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class SetPermissionsAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Get everyting you need, for example from Web.config
        }
        (...)
    }
