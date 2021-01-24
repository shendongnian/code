    public List<String> Select(String Path)
    {
        List<String> list = new List<String>();
        using (SQLiteCommand fmd = this.conn.CreateCommand())
        {
            fmd.CommandText = "SELECT * FROM FILE WHERE Path = @path";
            fmd.Parameters.Add(new SQLiteParameter("@path", Path));
            fmd.CommandType = CommandType.Text;
            SQLiteDataReader r = fmd.ExecuteReader();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    list.Add(r.GetString(0));
                    list.Add(r.GetString(1));
                    list.Add(r.GetString(2));
                }
            }
            else
            {
                return null;
            }
        }
        return list;
    }
