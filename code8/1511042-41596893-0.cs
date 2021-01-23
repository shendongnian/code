	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext() : base("SchoolContext", throwIfV1Schema: false)
		public DbSet<Student> etudiant { get; set;} // add this
	}
