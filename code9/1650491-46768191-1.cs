    using (MySqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
               //replace with your original columns names from the table
            list.Add(new Person(reader.GetInt32("id"),reader.GetString("Imie "),reader.GetDateTime("Uro "),reader.GetString("Pass"));
          }
        }
