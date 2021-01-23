    public class SharedDbContext : IdentityDbContext<ApplicationUser> {
		private const string SharedSchemaName = "shared";
		public DbSet<Foo> Foos{ get; set; }
		public SharedDbContext(DbContextOptions<SharedDbContext> options)
			: base(options) {}
		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.HasDefaultSchema(SharedSchemaName);
			base.OnModelCreating(modelBuilder);
		}
	}
