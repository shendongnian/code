    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    public class ApplicationUserRole: IdentityUserRole<string>
    {
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    public class ApplicationUserClaim: IdentityUserClaim<string>
    {
         public virtual ApplicationUser ApplicationUser { get; set; }
    }
