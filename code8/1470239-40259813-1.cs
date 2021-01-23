    protected override void OnAuthorization(AuthorizationContext filterContext)
    {
        // Get user id (create if not exists) using 
        // filterContext.HttpContext.User.Identity.Name
        // Set  generic principal using Id
        IPrincipal principal = new GenericPrincipal(
        new GenericIdentity("myuserid"), new string[] { "myrole" });
        HttpContext.Current.User = principal;
    }
