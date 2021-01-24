    using(SQLiteConnection lCon = new SQLiteConnection(DB_CONN_STR))
    {
        SqliteDataReader reader = ExecuteReader(lCon, "SELECT * FROM MyTable");
        while(reader.Read())
        {
            // do stuff...
        }
    }
