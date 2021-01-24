    using (OleDbConnection conn = new OleDbConnection(connStr))
    {
        conn.Open();
        using (OleDbCommand cmd1 = new OleDbCommand(sql))
        {                   
            cmd1.ExecuteNonQuery();
        }
        conn.Close();
    }
