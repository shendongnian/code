    public List<string[]> ExecuteQuery(string command)
    {
        List<string[]> records = new List<string[]>();
        using(com = new MySqlCommand(command, con))
        using(reader = com.ExecuteReader())
        {
            while (reader.Read())
            {
                string[] row = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount i++)
                    row[i] = reader[i].ToString();
                records.Add(row);
            }
        }
        return records;
    }
