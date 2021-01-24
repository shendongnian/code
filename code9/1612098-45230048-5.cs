    public LoginResult ValidateUserStoredProcedure(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentNullException("username");
    
        //set the password to empty if it is null
        password = password ?? "";
    
        //create the connection
        using (var connection = new SqlConnection(Configuration.ConnectionString))
        {
            var result = new LoginResult
            {
                AttemptsRemaining = 5,
                Status = LoginStatus.InvalidCredentials
            };
            try
            {
                using (var command = new SqlCommand("EXEC ValidateUser @username, @password", connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Status = ((LoginStatus)(int)reader["Result"]);
                            result.AttemptsRemaining = (int)reader["AttemptsRemaining"];
                            break;
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
    
                Debug.WriteLine("Error on sql query:" + ex.Message);
                return result;
            }
        }
    }
