	public interface IUserService{
	  Task<AspNetUser> GetByIdAsync(Guid id);
	}
	
	public class UserService : IUserService
	{
	    // you can leave MyDbContext unsealed or you can use an interface on this as well depending on your needs
		private readonly MyDbContext dbContext;
		public UserService(MyDbContext dbContext) {
		  this.dbContext = dbContext;
		}
		
		public Task<AspNetUser> GetByIdAsync(Guid id)
		{
			if(id == Guid.Empty())
				return Task.FromResult(null as AspNetUser);
			return dbContext.AspNetUsers.SingleOrDefaultAsync(user => user.Id == id);
		}
	}
