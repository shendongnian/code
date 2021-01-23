    public string[] getResult(string query, string ColumnName)
    {
        List<string> results = new List<string>();
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.CommandTimeout = 0;
        SqlDataReader reader = cmd.ExecuteReader();
        int col = reader.GetOrdinal(ColumnName);
        while (reader.Read())
        {
            results.Add(reader.GetString(col));
        }
        reader.Close();
        return results.ToArray();
    }
