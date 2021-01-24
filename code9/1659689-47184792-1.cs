    var cmd = new SqlCommand
    {
        CommandText = "uspTest",
        CommandTimeout = 300,
        CommandType = CommandType.StoredProcedure
    };
    var da = new SqlDataAdapter
    {
        SelectCommand = cmd
    };
    using (var conn = new SqlConnection(ConnString))
    {
        conn.Open();                
        conn.InfoMessage += Conn_InfoMessage;
        var ds = new DataSet();
        cmd.Connection = conn;
        da.Fill(ds);
        //Do something with the dataset
    }
