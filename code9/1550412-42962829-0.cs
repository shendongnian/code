    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DB", throwIfV1Schema: false) { }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        // extra entities added here 
        public DbSet<ScheduleRequest> ScheduleRequests { get; set; }
    }
