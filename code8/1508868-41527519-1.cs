    public List<string> AlleProducten(string commandText)
    {
        List<string> names = new List<string>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(commandText, conn))
        {
            conn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                while(rdr.Read())
                    names.Add(rdr.GetString(0));
            }
            conn.Close();
       }
       return names;
