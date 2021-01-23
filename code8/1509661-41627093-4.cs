    public class MyIdentityDbContext : IdentityDbContext<IdentityUser> {
        public MyIdentityDbContext()
            : base("MembershipConnection") { }
        public static MyIdentityDbContext Create() {
            return new MyIdentityDbContext();
        }
    }
