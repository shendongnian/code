    var connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        // Do your insert here;
    }
