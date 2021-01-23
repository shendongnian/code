    using (var reader = command.ExecuteReader())
    {
      int col1Ordinal = reader.GetOrdinal("Column1");
      int col2Ordinal = reader.GetOrdinal("Column2");
      while (reader.Read())
      {
        int col1 = (int)reader[col1Ordinal];
        string col2 = (string)reader[col2Ordinal];
        // do something with col1 and col2's values
      }
    }
