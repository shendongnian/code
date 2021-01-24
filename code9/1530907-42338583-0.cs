    private void AnotherMethod()
    {
       using (var ts = new TransactionScope(TransactionScopeOption.Suppress))
       {
           BackgroundJob.Enqueue(() => MyJob());
           ts.Complete();
       }
       
       SomeWork();
    }
