    while (oSqlDataReader.HasRows)
    {
      while (oSqlDataReader.Read())
      {
        // oSqlDataReader.Getdata...
      }
      oSqlDataReader.NextResult();
    }
