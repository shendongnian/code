       public TransactionScope CreateTransactionScope(TimeSpan timeout)
        {
            SetTransactionManagerField("_cachedMaxTimeout", true);
            SetTransactionManagerField("_maximumTimeout", timeout);
              var transactionScopeOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted,
                    Timeout = timeout
                };
            return new TransactionScope(TransactionScopeOption.RequiresNew, transactionScopeOptions);
        }
          private void SetTransactionManagerField(string fieldName, object value)
        {
            typeof(TransactionManager).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, value);
        }
