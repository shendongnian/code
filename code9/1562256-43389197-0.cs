    using (var connection = new MySqlConnection("server = localhost; User Id = root; password = ; database = documente;"))
    {
        connection.Open(); // open connection before using it
        string agenti = "SELECT * FROM `agenti` WHERE `ID` = @id";
        using (var cmd = new MySqlCommand(agenti, connection))
        {
            cmd.Parameters.AddWithValue("@ID", idagent);
            using (MySqlDataReader result = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                var myArray = new string[] { };
                while (result.Read())
                {
                    myArray[0] = (string)result["Nume Agent"];
                    myArray[1] = (string)result["Telefon"];
                    myArray[2] = (string)result["Sigiliu"];
                    myArray[3] = (string)result["Legitimatie"];
                    myArray[4] = (string)result["Prefix"];
    
                }
                result.Close();
            }
        }
    }
