	public class YourContext : DbContext
	{
	  public DbSet<Company> Companys { get; set; }
	  public DbSet<HeadOffice> HeadOffices { get; set; }
	  public DbSet<BranchOffice> BranchOffices { get; set; }
	  public YourContext(DbContextOptions<YourContext> options)
		: base(options)
	  {
	  }
	}
