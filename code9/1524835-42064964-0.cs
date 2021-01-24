     using (var session = NhibernateHelper.OpenSession())
     {
          using(var transaction = session.BeginTransaction())
          {
               try
               {
                   //
                   // Add a block of code here which queries and
                   // modifies data
                   //
                   //
                   transaction.Commit();
               }
               catch(Exception ex)
               {
                    transaction.RollBack();
                    throw;
               }
          }
     }
