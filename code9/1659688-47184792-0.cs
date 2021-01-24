    var cmd = new SqlCommand
    {
        CommandText = "uspTest",
        CommandTimeout = 300,
        CommandType = CommandType.StoredProcedure
    };
    using (var conn = new SqlConnection(ConnString))
    {
        conn.Open();                
        conn.InfoMessage += Conn_InfoMessage;
        
        cmd.Connection = conn;
        cmd.ExecuteNonQuery();                
    }
