    public string ExecuteScalar(string sql)
    {
        using(SQLiteConnection cnn = new SQLiteConnection(dbConnection))
        using(SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
        {
            cnn.Open();
            object value = mycommand.ExecuteScalar();
            return (value != null ? value.ToString() : "";
        }
    }
