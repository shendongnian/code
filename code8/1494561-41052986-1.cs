    using (var db = dbFactory.OpenDbConnection())
    using (var dbCmd = db.CreateCommand())
    {
        dbCmd.CommandType = System.Data.CommandType.StoredProcedure;
        dbCmd.CommandText = "stored procedure...";
        dbCmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@mobile", request.mobile));
        MySql.Data.MySqlClient.MySqlParameter message = new MySql.Data.MySqlClient.MySqlParameter("@message", "");
        message.Direction = System.Data.ParameterDirection.Output;
        dbCmd.Parameters.Add(message);
        gender.Direction = System.Data.ParameterDirection.Output;
        r = dbCmd.ExecuteReader();
        return new PostAccountResponse() { message = string.Format("{0}", message.Value };
    }
