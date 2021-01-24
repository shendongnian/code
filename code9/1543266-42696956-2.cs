    	public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(
                this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
    	
       public class ApplicationRole : IdentityRole
        {
            public ApplicationRole() : base() { }
            public ApplicationRole(string name) : base(name) { }
            public string Description { get; set; }
        }
