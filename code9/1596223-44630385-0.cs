    try
    {
      using ( TransactionScope scope = new TransactionScope() )
      {
         _service1.DoUpdate();
         _service1.Save();
         _service2.DoUpdate();
         _service2.Save();
         scope.Complete();
      }
    }
    catch
    {
       // rollback occurs since the transaction was not completed
    }
