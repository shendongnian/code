    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<IdentityUserRole<string>> Roles { get; } = new List<IdentityUserRole<string>>();
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; } = new List<IdentityUserClaim<string>>();
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; } = new List<IdentityUserLogin<string>>();
    }
