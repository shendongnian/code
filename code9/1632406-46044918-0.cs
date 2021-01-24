    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]
    public class PermissionFilter : AuthorizeAttribute{
    
        public RoleType[] Roles;
    
        public PermissionFilter(params RoleType[] roles){
            Roles = roles;
        }
    
        protected override bool AuthorizeCore(HttpContextBase httpContext){
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
    
            if (!httpContext.User.Identity.IsAuthenticated)
                return false;
            try{
                Usuario usuario = httpContext.Session["Usuario"] as Usuario;
                RoleType role = usuario.role;
                Boolean contain = Roles.Contains<RoleType>((RoleType)role);
                Console.WriteLine("Contem Role: " + contain);
    
                if (!Roles.Contains<RoleType>((RoleType)role)){
                    return false;
                }
    
                return true;
            }catch (Exception e){
                Debug.WriteLine("PermissionFilter AuthorizeCore: " + e.Message);
                return false;
            }       
        }
    
    
        public override void OnAuthorization(AuthorizationContext filterContext){
            base.OnAuthorization(filterContext);
    
            if (filterContext.Result is HttpUnauthorizedResult)
                filterContext.HttpContext.Response.Redirect("/Home/acessoNegado");
        }
    }
