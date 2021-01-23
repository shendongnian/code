     using (SqlCeConnection conn =
        new SqlCeConnection(@"Data Source=C:\data\AdventureWorks.sdf;"))
     {
        conn.Open();
       using (SqlCeTransaction tx =
         conn.BeginTransaction(IsolationLevel.ReadCommitted))
         {
         using (SqlCeCommand cmd1 = conn.CreateCommand())
          {
            cmd1.Transaction = tx;
            try
            {
                cmd1.CommandText = "INSERT INTO FactSalesQuota " +
                    "(EmployeeKey, TimeKey, SalesAmountQuota) " +
                    "VALUES (2, 1158, 150000.00)";
                cmd1.ExecuteNonQuery();
                tx.Commit(CommitMode.Immediate);
            }
         }
        }
      }
