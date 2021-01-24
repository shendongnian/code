    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute() 
        {
            this.Roles = ConfigurationManager.AppSettings["ADGroupReader"].ToString();
        }
        // other stuff
    }
