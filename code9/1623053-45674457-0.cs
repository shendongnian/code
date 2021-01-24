    public DataTable SetQuery(string sSQL)
    {
        DataTable dt = new DataTable();
        using (MySqlCommand cmd = new MySqlCommand(sSQL, Connection))
        {
            _cmd.ExecuteNonQuery();
            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
        }
        return dt;
    }
