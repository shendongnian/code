    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureSql"].ToString()))
    using (SqlCommand command = new SqlCommand())
    {
        connection.Open();
        command.Connection = connection;
        // Rest of code here.
    }
