	public interface IUserImmediateRepository
	{
		void UpdateName(Int32 id, String newName);
	}
	public class UserImmediateRepository : IUserImmediateRepository
	{
		public UserImmediateRepository()
		{
		}
		public void UpdateName(Int32 id, String newName)
		{
			using(var singleUseContext = new MyDbContext())
			{
				var repo = new UserRepository(singleUseContext);
				repo.UpdateName(id, newName);
				singleUseContext.SaveChanges();
			}
		}
	}
