    string query = "UPDATE [@dbname].[dbo].[MasterDatas] "
                    + "SET SupervisorGPID = @gpid"+
                   + " WHERE UserName = 'strenev'"; // here surrounding '' is missing
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.Add("@dbName", SqlDbType.NVarchar);
        command.Parameters["@dbName"].Value = dbName;
        command.Parameters.Add("@gpID", SqlDbType.Int);
        command.Parameters["@gpID"].Value = gpid;
        
        try
        {
            connection.Open();
            Int32 rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("RowsAffected: {0}", rowsAffected);
        }
        catch (Exception ex)
        {
            //catch OR throw ex;
        }
    }
