    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole(){ }
        public ApplicationRole(string roleName)
            : base(roleName)
        {
        }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
