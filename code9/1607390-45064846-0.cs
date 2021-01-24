    using (var context = new CurrentContext())
    {
        using (var scope = new TransactionScope())
        {
            context.Database.Connection.Open();
            using (var connection = new SqlConnection(context.Database.Connection.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT 1", connection))
                {
                    var x = command.ExecuteNonQuery();
                }
            }
    
        }      
    }
