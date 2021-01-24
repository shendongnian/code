    using (OleDbConnection conn = new OleDbConnection(connStr))
    using(OleDbCommand cmd1 = new OleDbCommand(sql))
    {
        conn.Open();
        cmd1.ExecuteNonQuery();
        conn.Close();
    }
