    using (var context = new DbContext())    
    {
        var dataTable = new DataTable();
        var connection = (SqlConnection)context.Database.Connection;
        if (connection != null && connection.State == ConnectionState.Closed)
            connection.Open();
        
        using (var adapter = new SqlDataAdapter(queryString, connection))
            adapter.Fill(dataTable);
    }
