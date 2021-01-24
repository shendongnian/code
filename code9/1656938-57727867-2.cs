    public class MyClass
    {
        private readonly ITransactionInterface transaction;
        public MyClass(Func<TransactionType, Interfaces.ITransactionInterface> transactionResolver)
        {
            transaction = transactionResolver.Invoke(TransactionType.TypeA);
        }
    }
