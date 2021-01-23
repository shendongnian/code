    string insertPerson = 
         "INSERT INTO myentities(Name) VALUES (@first_name);"
       + "INSERT INTO secondtable(Id, Name,myentities) VALUES (@ID, @city, LAST_INSERT_ID());";
    string ConnectionString = "server=localhost; password = 1234; database = DB ; user = Jack";
    using (var Connection = new MySqlConnection(ConnectionString))
    using (var command = new MySqlCommand(insertPerson, mConnection))
    {
        //guessing at column types and lengths here 
        command.Parameters.Add("@first_name", MySqlDbType.VarChar, 50).Value = "Jack";
        var id = command.Parameters.Add("@ID", MySqlDbType.Int32);
        command.Parameters.Add("@city", MySqlDbType.VarChar, 50).Value = "Frank";
        mConnection.Open();
        for (int i = 1; i <= 100000; i++)
        {
            id.Value = i;
            command.ExecuteNonQuery();
        }
    }
