    [OperationBehavior(TransactionScopeRequired = true)]
    public void Update(IEnumerable<string> values)
    {
        foreach (string value in values)
        {
            db1Access.Update(value);
        }
    }
