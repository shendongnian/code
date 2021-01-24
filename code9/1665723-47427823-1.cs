    public class ApplicationDbContext : DbContext //change DbContext name appDbContext by ApplicationDbContext
    {
        public DbSet<Appointments> Appointments { get; set; }
    
        public ApplicationDbContext(string connectionName="IdentityConnection"): base(connectionName)
        {
        }
    }
