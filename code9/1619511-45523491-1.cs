	public class UserContextWrapper
	{
		private readonly UserContext _context;
		
		public UserContextWrapper()
		{
			_context = new UserContext();
		}
		
		private class UserContext : DbContext
		{
			public DbSet<User> Users { get; set; }
		}
	}
