    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    [ComVisible(true)]
    [Serializable]
    public sealed class MyPrincipalPermissionAttribute : CodeAccessSecurityAttribute {
        public string Name { get; set; }
        public string Role { get; set; }
        public bool Authenticated { get; set; } = true;
        public MyPrincipalPermissionAttribute(SecurityAction action)
            : base(action) {
        }
        public override IPermission CreatePermission() {
            if (this.Unrestricted)
                return new PrincipalPermissionProxy(new PrincipalPermission(PermissionState.Unrestricted));
            return new PrincipalPermissionProxy(new PrincipalPermission(this.Name, this.Role, this.Authenticated));
        }
    }
