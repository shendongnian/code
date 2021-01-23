<!-- -->
    public IEnumerable<DataLine> ReadAllLines()
    {
        ...
        using (OleDbDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                yield return new DataLine() { Zoo = reader.GetString(0).Trim(), Animal = reader.GetString(1).Trim(), Mn = reader.GetInt32(2), Tu = reader.GetInt32(3) };
            }
        }
    }
