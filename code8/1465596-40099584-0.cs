    using (var context = new YourContext())
        {
         using (var dbContextTransaction = context.Database.BeginTransaction())
         {
           //Lock the table during this transaction
           context.Database.ExecuteSqlCommand("SELECT 1 FROM TABLE WITH (TABLOCKX)
        WAITFOR DELAY '00:03:00'");
            
                //your work here
               
                scope.Commit();
          }
    }
