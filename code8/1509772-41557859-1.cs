    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureSql"].ToString()))
    using (SqlCommand command = new SqlCommand("", connection))
    {
        // Do note that you still have to open the connection here.
        connection.Open();
        // Rest of code here.
    }
