    public class ApplicationDbContext : IdentityDbContext<SchedulerUser>
    {
        public virtual DbSet<Item> Items { get; set; }
        
        //some code are excluded for clarity
    }
