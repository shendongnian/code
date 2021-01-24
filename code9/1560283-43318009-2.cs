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
                    .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));
            var identityName = userService.CurrentUser.Name;
            var now = timeService.CurrentTime;
            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as AuditableEntity;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = identityName ?? "unknown";
                    entity.CreatedDate = now;
                }
                entity.UpdatedBy = identityName ?? "unknown";
                entity.UpdatedDate = now;
            }
            return base.SaveChanges();
        }
    }
