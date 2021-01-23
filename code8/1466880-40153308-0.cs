    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        private readonly ApplicationDbContext context;
        public ApplicationUserManager(ApplicationDbContext context, /*... other parameters*/) : base(store)
        {
            this.context = context;
            //... other configuration bits
        }
        
        public IEnumerable<ApplicationUser> GetUsersInRole(string roleName)
        {
            if (String.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentNullException(nameof(roleName));
            }
            var role = context.Roles.FirstOrDefault(r => r.Name == roleName);
            if (role == null)
            {
                throw new Exception($"Role with this name not found: {roleName}");
            }
            var users = context.Users.Where(u => u.Roles.Any(r => r.RoleId == role.Id)).ToList();
            return users;
        }
        
        // the rest of User manager methods
    }
