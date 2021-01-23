    // For ASP.Net MVC 5 simply inherit from AuthorizationAttribute and override the methods.
    public class AccessControlAttribute : Attribute, IAuthorizationFilter
    {
        private readonly Roles role;
        public AccessControlAttribute(Roles role) {
            this.role = role;
        }
        private Boolean AuthorizationCore(AuthorizationFilterContext context) {
            var username = context.HttpContext.Request.Cookies["loginCookie_username"];
            var password = context.HttpContext.Request.Cookies["loginCookie_password"];
            if (role == Roles.FakeFullAccess) {
                username = "FAKE";
                goto final;
            }
            DbContext db = (DbContext) context.HttpContext.RequestServices.GetService(typeof(DbContext));
            if (username != null && password != null) {
                var findUser = db.Set<Login>().Find(username);
                if (findUser != null && findUser.Password.Equals(password) && findUser.RoleId == (int)role) {
                    goto final;
                }
            }
            return false;
            final: {
                context.HttpContext.User.AddIdentity(new System.Security.Principal.GenericIdentity(username));
                return true;
            }   
        }
        private void HandleUnauthorizedRequest(AuthorizationFilterContext context) {
            context.Result = new RedirectToRouteResult(new {
                area = "",
                controller = "",
                action = ""
            });
        }        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (AuthorizationCore(context))
            {
                if (role == Roles.FakeFullAccess) {
                    context.HttpContext.Request.Headers.Add("Render", "FakeAccess");
                }
                else if (role == Roles.Admin)
                {
                    context.HttpContext.Request.Headers.Add("Render", "AdminAccess");
                }
            }
            else {
                HandleUnauthorizedRequest(context);
            }
        }
    }
