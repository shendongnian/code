    async Task DoSomething()
    { 
        await UsingAsync.Do(
            // this is the disposable usually passed to using(...)
            new TransactionScope(TransactionScopeAsyncFlowOption.Enabled), 
            // this is the body of the using() {...}
            async transaction => {
                await Task.Delay(100);   // do any async stuff here...
                transaction.Complete();  // mark transaction for Commit
            } // <-- the "dispose" part is also awaitable
        );
    }
