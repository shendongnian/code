    using (var uow = uowManager.Begin(TransactionScopeOption.Suppress))
    {
        using (var con = new SqlConnection(ConnectionString))
        {
            con.Open();
    
            using (var command = new SqlCommand("select * from ... ", con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                }
            }
        }
    
        uow2.Complete();
    }
