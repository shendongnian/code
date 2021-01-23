    using(OracleConnection conn = new OracleConnection(oradb))
    {
        conn.Open();
        OracleCommand cmd= conn.CreateCommand();
        cmd.Connection = conn;
    
        cmd.CommandText = @"Select * FROM Plan_Table Where ID=@ID";
        cmd.Parameters.AddWithValue("@ID", idWhichYouSpecify);
        
        DataTable tbl = new DataTable();
    
        using(OracleDataAdapter da = new OracleDataAdapter(cmd))
        {
            da.Fill(tbl);
        }
    }
