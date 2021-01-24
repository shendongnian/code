    public class AppSettingsDynamicRolesAuthorizeAttribute : AuthorizeAttribute
    {
        public AppSettingsDynamicRolesAuthorizeAttribute(params string[] roleKeys)
        {
            List<string> roles = new List<string>(roleKeys.Length);
            foreach (var roleKey in roleKeys)
            {
                roles.Add(WebConfigurationManager.AppSettings[roleKey]);
            }
            this.Roles = string.Join(",", roles);
        }
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (Convert.ToBoolean(WebConfigurationManager.AppSettings["IsTestEnvironment"]))
            {
                filterContext.RequestContext.Principal = new GenericPrincipal(
                    new GenericIdentity("Spoofed-Oscar"),
                    new string[] { WebConfigurationManager.AppSettings[Role.Administrator] });
            }
            base.OnAuthorization(filterContext);
        }
    }
    public static class Role
    {
        public const string Administrator = "Administrator";
        public const string OtherRole = "OtherRole";
    }
