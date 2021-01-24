    public string ReadString(string txtQuery)
    {
        using(SQLiteConnection con = Openconn())
        using(SQLiteCommand cmd = new SQLiteCommand(txtQuery, con))
        {
            object result = cmd.ExecuteScalar();
            return (result == null ? "" : result.ToString());
        }
    }
