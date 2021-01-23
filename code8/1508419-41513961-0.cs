    connection.Open();
                string query = "UPDATE [dbo].[EmailPassword] SET HashedPassword = @hashedPassword, Salt = @salt, ForgotHisPassword = @forgotHisPassword where Email = @email";
            SqlCommand command = new SqlCommand(query, connection);
            string recoveredPassword = RandomPasswordGenerator.Generate();
            PasswordHash passwordHash = new PasswordHash();
            byte[] newHashedPassword = passwordHash.ComputeHash(recoveredPassword);
            command.Parameters.Add("@hashedPassword", SqlDbType.Varchar); // you have to send the data type explicitely
            command.Parameters["@hashedPassword"].Value = Encoding.ASCII.GetBytes(newHashedPassword); 
            command.Parameters.AddWithValue("@salt", passwordHash.saltAsString);
            command.Parameters.AddWithValue("@forgotHisPassword", 1);
            command.Parameters.AddWithValue("@email", TxtSendPasswordToEmail.Text);
            command.ExecuteNonQuery();
