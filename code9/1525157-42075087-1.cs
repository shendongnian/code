	public class MyDbContext : DbContext
	{
		public MyDbContext() : base("Name=bcard_portal")
		public DbSet<HelpRequest> HelpRequests { get; set; }
	}
	
	
