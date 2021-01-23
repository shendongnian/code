    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class AuthorizeRoleOrSuperiorAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        private MyAppRole _authorizedRole;
    
        public AuthorizeRoleOrSuperiorAttribute(MyAppRole authorizedRole)
        { //Breakpoint here
            _authorizedRole = authorizedRole;
        }
    
        public override void OnAuthorization(AuthorizationContext filterContext)
        { //Breakpoint here
            base.OnAuthorization(filterContext);
    
            if (!UserInfo.GetUserRoles().Any(r => (int)r >= (int)_authorizedRole))
                throw new UnauthorizedAccessException(ErrorsModule.RoleMissing);
        }
    }
