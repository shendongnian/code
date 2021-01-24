    using (var connection = new MySqlConnection(myConnectionString))
    using (var command = connection.CreateCommand())
    {
        connection.Open();
        command.CommandText = "SELECT * FROM person";
        Modells.Person helpPerson;
        using (reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                helpPerson = new Modells.Person(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader.GetInt32(5));
                persons.Add(helpPerson);
            }
        }
         
        connection.Close();
    }
