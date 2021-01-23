	public interface IFilterHelper<T, R> where R : ISearchModel<T>
	{
		void Filter(R model, ref IQueryable<T> dbModel);
	}
	
	public class UserFilterHelper : IFilterHelper<ApplicationUser, UserSearchModel>
	{
		public void Filter(UserSearchModel model, ref IQueryable<ApplicationUser> dbModel)
		{
		}
	}
