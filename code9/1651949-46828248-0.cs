	public abstract class AccountManager
	{
		public virtual void DeleteAccount(string userId)
		{
		}
		public virtual void AccountDetail(string userId)
		{
		}
	}
	public class Administrator : AccountManager
	{
	}
	public class Moderator : AccountManager
	{
		public override void DeleteAccount(string userId)
		{
			throw new Exception("You have not a right permission");
		}
	}
