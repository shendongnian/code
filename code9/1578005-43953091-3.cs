    public DataSet GetDataSet(string ConnectionString, string SQL)
    {
        SQLiteConnectionconn = new SQLiteConnection(ConnectionString);
        SQLiteDataAdapter da = new SQLiteDataAdapter ();
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = SQL;
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
    
        conn.Open();
        da.Fill(ds);
        conn.Close();
    
        return ds;
    }
