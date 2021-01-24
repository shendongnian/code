    public class CustomPricipal : IPrincipal
    {        
        public CustomPricipal(string username)
        {
            this.Identity = new CustomIdentity(username);
        }
        public IIdentity Identity
        {
            get;
            private set;
        }
        public bool IsInRole(string role)
        {
            return this.Identity != null && ((CustomIdentity)this.Identity).Roles.Any(x => x.ToLower() == role.ToLower());
        }
    }
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(string name)
        {
            // We can fetch the user information from database and create custom properties
            this.Name = name;
            this.IsAuthenticated = true;
            this.AuthenticationType = "Forms";
            this.Roles = new List<string>() { "Admin", "SuperAdmin" };
        }
        public string AuthenticationType
        {
            get;
            private set;
        }
        public bool IsAuthenticated
        {
            get;
            private set;
        }
        public string Name
        {
            get;
            private set;
        }
        public List<string> Roles
        {
            get;
            private set;
        }
    }
