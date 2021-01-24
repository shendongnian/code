    public MyPermissionsFilter : AuthorizeAttribute
    {
        private readonly string _permissionName;
        public PermissionsFilter(string permissionName)
        {
            _permissionName = permissionName;
        }
    }
