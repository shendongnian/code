    DateTime d = GetMyDateTimeValueFromUser();
    string sql = "pretend SQL comnand with a datetime @variable";
    using (var cn = new MySqlConnection("connection string here"))
    using (var cmd = new MySqlCommand(sql, cn))
    {
        cmd.Parameters.Add("@Variable", MySqlDbType.Timestamp).Value = d;
        cn.Open();
        //pick one.
        cmd.ExecuteReader();
        cmd.ExecuteNonQuery();
    }
