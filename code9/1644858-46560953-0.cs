    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<YogaSpaceEvent> YogaSpaceEvent { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public ApplicationDbContext(string connectionString) : base(connectionString, throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
    public class YogaSpaceEvent
    {
        public int YogaSpaceEventId { get; set; }
        public string YogaSpaceEventName { get; set; }
        public DateTime CreateTime { get; set; }
    }
