    connection.Open();
    SqlTransaction transaction = connection.BeginTransaction();
    
    try
           {
               Execute Sp1;
               Execute Sp2;
           }
           catch (Exception)
           {
               transaction.Rollback();
               connection.Close();
           }
            
           transaction.Commit();
