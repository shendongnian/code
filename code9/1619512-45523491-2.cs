	public class SecuredUserService : ISecuredUserService
	{
		private readonly UserContext _context;
		
		public SecuredUserService()
		{
			_context = new UserContext();
		}
		// expose a secure interface / method
		public bool TryChangePassword(IUser user, string value)
		{
			return false;
		}
		// secure the context
		private class UserContext : DbContext
		{
			public DbSet<User> Users { get; set; }
		}
		// secure the model
		private class User : IUser
		{
			public int Id { get; set; }
		}
	}
