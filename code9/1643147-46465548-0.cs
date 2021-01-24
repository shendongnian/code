    public class DeviceContext : DbContext
    {
        public DeviceContext(DbContextOptions<DeviceContext> options) : base (options)
        {
        }
    
        public DbSet<Device> Devices { get; set; }
        public DbSet<IpMac> IpMacs { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<IpMac>().ToTable("IpMac");
          modelBuilder.Entity<Device>().ToTable("Device");
          Logger.Log("DeviceContext: Database & Tables SET.");
        }
    }
