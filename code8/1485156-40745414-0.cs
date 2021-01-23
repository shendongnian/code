    public class DashboardContext : DbContext
    {
        private readonly TableConfiguration tableConf;
        public DashboardContext(DbContextOptions<DashboardContext> options, IOptions<TableConfiguration> tableConf) : base(options)
        {
            this.tableConf = tableConf.Value;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DashboardData>(entity =>
            {
                entity.ToTable(this.tableConf.DatabaseTable, this.tableConf.DatabaseSchema);
            });
        }
        public virtual DbSet<DashboardData> DashboardData { get; set; }
    }
