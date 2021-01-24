    #region CustomAuthorizationAttribute
    public class CustomAuthorizationAttribute : AuthorizeAttribute
    {
        
        private PermissionRepository _permission = new PermissionRepository();
        private PermissionFuncRepository _permissionFun = new PermissionFuncRepository();
        // roles start
        public string IdentityRoles
        {
            get { return _permissionName ?? String.Empty; }
            set
            {
                _permissionName = value;
            }
        }
        private string _permissionName;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //do the base class AuthorizeCore first
            if (httpContext.User.Identity.IsAuthenticated)
            {
                string RoleID = FormsAuthentication.Decrypt(httpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[1];
                var permisionID = _permissionFun.FindByName(_permissionName);
                if(permisionID != null)
                {
                    var permis = _permission.GetPermission().Where(a => a.Perm_PermFuncID == permisionID.PermFunc_ID && a.Perm_RollID.ToString() == RoleID).FirstOrDefault();
                    if (permis != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //if the user is not logged in use the deafult HandleUnauthorizedRequest and redirect to the login page
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            //if the user is logged in but is trying to access a page he/she doesn't have the right for show the access denied page
            {
                filterContext.Result = new RedirectResult("~/Home/AccessDenied");
            }
        }
       
    }
    #endregion
