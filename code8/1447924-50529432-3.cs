    public class DomainDbContext : IdentityDbContext<ApplicationUser> {
		public readonly string SchemaName;
		public DbSet<Foo> Foos{ get; set; }
		public DomainDbContext(ICompanyProvider companyProvider, DbContextOptions<DomainDbContext> options)
			: base(options) {
			SchemaName = companyProvider.GetSchemaName();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.HasDefaultSchema(SchemaName);
			base.OnModelCreating(modelBuilder);
		}
	}
