    reader = cmd.ExecuteReader();
    try
    {
      while(myReader.Read()) 
      {
        while (reader.Read())
        {
            cardID = reader["CardID"].ToString();
        }
    }
    finally
    {
      myReader.Close();
    }
    ...
    reader = cmd.ExecuteReader();
    try
    {
      while(myReader.Read()) 
      {
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                quantity = reader["Quantity"].ToString();
            }
      }
    }
    finally
    {
      myReader.Close();
      myConnection.Close();
    }
