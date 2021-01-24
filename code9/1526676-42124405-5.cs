    public class MockApplicationUser : ApplicationUser {
        private readonly ICollection<ApplicationRoles> roles
        public MockedApplicationUser(List<ApplicationRoles> roles) : base() {
            this.roles = roles;
        }
        public override ICollection<ApplicationRoles> Roles {
            get { return roles; }
        }
    }
