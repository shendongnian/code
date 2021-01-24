    public class TestDbContext : IdentityDbContext<ApplicationUser>, ITestDbContext
    {
        public virtual DbSet<Episode> Episodes { get; set; }
    
        public ApplicationDbContext()
        {
    		// ...
        }
    }
