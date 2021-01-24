     using (ISession session)
     using (var transaction = session.BeginTransaction())
     {
         var query = session.CreateQuery(
             $"DELETE FROM Table WHERE id = :id")
                .SetParameter("id", someId);
         query.ExecuteUpdate();
         
         transaction.Commit();
     }
