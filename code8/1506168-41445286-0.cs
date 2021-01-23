    public abstract class AbstractService 
	{
	}
	
	public interface IService
	{
	}
	
	public interface ITransaction
	{
	}
	
	
	public static class TransactionFactory 
	{
        // created them as extensions, but you could remove *this*
		public static ITransaction Create(this AbstractService instance)
		{
			return new Transaction ();
		}
		
		public static ITransaction Create(this IService instance)
		{
			return new Transaction ();
		}
		
		private class Transaction : ITransaction
		{
			public Transaction ()
			{
			}
		}
	}
