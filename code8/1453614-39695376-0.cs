     public class RequireRoleAttribute : AuthorizeAttribute
        {
            public RoleEnum[] RequiredRoles { get; set; }
                 
    
            public RequireRoleAttribute()
            {
    
            }
    
            public RequireRoleAttribute(params RoleEnum[] roles)
                : this()
            {
                RequiredRoles = roles;
            }
    
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                var principle = httpContext.User;
    
                if (principle == null || principle.Identity == null || !principle.Identity.IsAuthenticated)
                {
                    return false;
                }
    
                if (RequiredRoles != null)
                {
                    if (!HasRole(RequiredRoles))
                    {
                        httpContext.Response.Redirect("/AccessDenied");
                    }
                }
    
                return base.AuthorizeCore(httpContext);
            }
    
    
            public bool HasRole(RoleEnum[] roles)
            {
                foreach (var role in roles)
                {
                    if (HasRole(role))
                        return true;
                }
    
                return false;
            }
    
            public bool HasRole(RoleEnum role)
            {
                return true if the user role has the role specified (read it from database for example)
            }
        }
