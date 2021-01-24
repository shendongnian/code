    public class UserRole : IdentityUserRoleBase
    {
        public virtual Role Role { get; set; } // add this to see roles
        public virtual User User { get; set; } // add this to see users
    }
