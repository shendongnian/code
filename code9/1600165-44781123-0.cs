      public class AuthorityAttribute : AuthorizeAttribute
        {
            private readonly string[] allowedroles;
            public AuthorityAttribute(params string[] roles)
            {
                this.allowedroles = roles;
            }
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                foreach (var role in allowedroles)
                {
                    if (PortalWebSessionManager.ActivePortalSettings.ActiveRoles != null)
                    {
                        foreach (IDynamics.IDynamicsPortal.DataComponent.Roles currentRole in PortalWebSessionManager.ActivePortalSettings.ActiveRoles)
                        {
                            if (currentRole.RoleName == role)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
