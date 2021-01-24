    public class ReaderAuthorizeAttribute : AuthorizeAttribute
    {
        public ReaderAuthorizeAttribute()
        {            
            this.Roles = System.Configuration.ConfigurationManager.AppSettings["ADGroupReader"];
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }
    }
