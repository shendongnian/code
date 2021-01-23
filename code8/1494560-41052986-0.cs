    using (var db = dbFactory.OpenDbConnection())
    {
        db.CommandType = System.Data.CommandType.StoredProcedure;
        db.CommandText = "stored procedure...";
        db.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("@mobile", request.mobile));
        MySql.Data.MySqlClient.MySqlParameter message = new MySql.Data.MySqlClient.MySqlParameter("@message", "");
        message.Direction = System.Data.ParameterDirection.Output;
        db.Parameters.Add(message);
        gender.Direction = System.Data.ParameterDirection.Output;
        r = db.ExecuteReader();
        return new PostAccountResponse() { message = string.Format("{0}", message.Value };
    }
