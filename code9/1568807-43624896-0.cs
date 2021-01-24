    private SqliteDataReader ExecuteReader(SQLiteConnection lCon, string sql)
    {
        lCon.Open();
        lCmd = new SQLiteCommand(sql, lCon);
        return lCmd.ExecuteReader();
    }
