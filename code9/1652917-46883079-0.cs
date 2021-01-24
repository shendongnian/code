    try
       {
          if (connection.State != ConnectionState.Open)
    
          {
              connection.Open();
          }
          SqlCommand command = new SqlCommand(sql, connection);
          SqlDataReader reader = command.ExecuteReader();
          while (reader.Read())
          {
             persons.Add(new Person(reader.GetInt32(0), reader.GetString(1)));
          }
      }
    catch(Exception e)
    {
             System.Diagnostics.Debug.WriteLine("Error in getPersons(): " + e.Message);
    }
      return persons;
  
