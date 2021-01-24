    internal void StartTestScope()
    {
        TransactionOptions options = new TransactionOptions();
        options.IsolationLevel = IsolationLevel.ReadUncommitted;
        _transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, options);
    }
