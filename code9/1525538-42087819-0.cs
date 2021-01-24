    public class ApplicationUser : IdentityUser<Guid, GuidUserLogin, GuidUserRole, GuidUserClaim>
        {
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                return userIdentity;
            }
            public ApplicationUser()
            {
               Departments = new Collection<Department>();
            }
    
            public ICollection<Department> Departments { get; set; }
        }
    public class UserNotification
    {
        public string UserId { get; private set; }
        public int DepartmentId { get; private set; }
        public ApplicationUser User { get; private set; }
 
        protected Department()
        {
        }
 
    }
