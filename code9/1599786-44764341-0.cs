    var opts = new TransactionOptions();
    opts.IsolationLevel = IsolationLevel.RepeatableRead;
    using (var txn = new TransactionScope(TransactionScopeOption.Required, opts))
    {
        // update command goes here.
        
        txn.Complete();
    }
