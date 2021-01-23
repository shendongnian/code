    public interface ITransactionFactory { }
    public abstract class AbstractService : ITransactionFactory	{ }
	
	public interface IService  : ITransactionFactory { }
    public static class TransactionFactory<T>
      where T : ITransactionFactory
	{
      public static ITransaction CreateTransaction(this T instance)
		{
			return new Transaction ();
		}
        // ....
