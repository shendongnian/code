    using System.Data.SqlClient;
    ...
    using (IDbConnection dbConnection = new SqlConnection(connectionString))
    {
        dbConnection.Open();
        // dbConnection.Execute(query, data);
    }
