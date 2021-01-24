    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class RequireFunction : AuthorizeAttribute
    {
        private string _function;
        
        public RequireFunction(string func) { _function = func; }
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User == null)
                return false;
    
            if (!httpContext.User.Identity.IsAuthenticated)
                return false;
    
            // modified code sample from question
            string mail = httpContext.User.Identity.Name;
            var user = _user.GetUserByMail(mail);
            var permFunc = _permissionfunc.FindByName(_function);
            var permission = _permission.checkIfPermitted(Convert.ToInt64(usr.Usr_Role_ID), permFunc.PermFunc_ID);
            return permission != null;
        }
    }
