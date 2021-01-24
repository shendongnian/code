    private static void CreateCommand(string queryString,
        string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }
    
    private void DeleteStuff()
    {
       string sql = "delete from MyTable where ID in (1, 2, 3);
       string myConnectionString = "<connection string goes here>";
       CreateCommand(sql, myConnectionString);
    }
