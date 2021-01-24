    using(MySqlConnection conn = new MySqlConnection("YourConnectionString"))
    {
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "insert into Crooks (FirstName, LastName, StreetName, SSN, CrimeID, DangerLevel, CrimeDescription) VALUES (@FirstName, @LastName, @StreetName, @SSN, @CrimeID, @DangerLevel, @CrimeDescription)";
    
            command.Parameters.AddWithValue("@FirstName", tbLASTNAME.Text.Trim());
            command.Parameters.AddWithValue("@LastName", tbStreetName.Text.Trim());
            /*
            ...
            AND SO ON WITH OTHER PARAMETERS
            ...
            */    
            command.ExecuteNonQuery();
            conn.Close();
    }
