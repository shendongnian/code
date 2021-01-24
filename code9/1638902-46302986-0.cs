         public class TransactionUtils
        {
        public static TransactionScope CreateTransactionScope()
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;
            transactionOptions.Timeout = TransactionManager.DefaultTimeout;
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }
    }
