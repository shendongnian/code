    public void ReadData(string txtQuery, Action<SQLiteDataReader> loader)
    {
        using(SQLiteConnection con = Openconn())
        using(SQLiteCommand cmd = new SQLiteCommand(txtQuery, con))
        using(SQLiteDataReader rd = cmd.ExecuteReader())
        {
            while(rd.Read())
                loader(rd);
        }
    }
