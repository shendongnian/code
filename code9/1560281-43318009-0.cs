    public abstract class AuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
    public class AuditableDbContext : DbContext
    {
        protected readonly IUserService userService;
        protected readonly DbContextOptions options;
        protected readonly ITimeService timeService;
    
        public BaseDbContext(DbContextOptions options, IUserService userService, ITimeService timeService) : base(options)
        {
            userService = userService ?? throw new ArgumentNullException(nameof(userService));
            timeService = timeService ?? throw new ArgumentNullException(nameof(timeService));
        }
    
        public override int SaveChanges()
        {
            // get entries that are being Added or Updated
            var modifiedEntries = ChangeTracker.Entries()
                    .TypeOf<AuditableEntity>()
                    .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            var identityName = userService.CurrentUser.
            var now = timeService.CurrentTime;
            foreach (var entry in modifiedEntries)
            {
                if (entry.State == EntityState.Added)
                {
                    CreatedBy = identityName ?? "unknown";
                    CreatedDate = now;
                }
                UpdatedBy = identityName ?? "unknown";
                UpdatedDate = now;
            }
            return base.SaveChanges();
        }
    }
