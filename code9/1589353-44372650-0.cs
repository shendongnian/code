    public MyPermissionsFilter : AuthorizeAttribute
    {
        private readonly string _permissionName;
        public PermissionsFilter(string permissionName)
        {
            _permissionName = permissionName;
        }
    }
    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        //Perform Check with _permissionName
       //Redirect to error / unauthorised
    }
