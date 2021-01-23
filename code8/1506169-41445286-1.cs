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
		public static ITransaction CreateTransaction(this AbstractService instance)
		{
			return new Transaction ();
		}
		
		public static ITransaction CreateTransaction(this IService instance)
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
