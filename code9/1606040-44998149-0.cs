    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string AuthenticationType { get; private set; }
        public CustomAuthorize(string authenticationType)
        {
            if (string.IsNullOrWhiteSpace(authenticationType))
            {
                throw new ArgumentNullException(nameof(authenticationType));
            }
            this.AuthenticationType = authenticationType;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.User.Identity.AuthenticationType.Equals(this.AuthenticationType, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }
            return base.AuthorizeCore(httpContext);
        }
    }
