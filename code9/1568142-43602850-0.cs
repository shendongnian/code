    using (var connection = new SqlConnection((string.Format(_conString, DBname))
    {
        using (var command = connection.CreateCommand())
        {
            connection.Open();
            command.CommandText = "delete  from " + tName + " where " + field +  " = " + condition ; 
            command.ExecuteNonQuery();
        }
    }
