    using (OleDbConnection conn = new OleDbConnection(connStr)){
        OleDbCommand cmd1 = new OleDbCommand(sql);
        conn.Open();
        cmd1.ExecuteNonQuery();
        conn.Close();
    }
