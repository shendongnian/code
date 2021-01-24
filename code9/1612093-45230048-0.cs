    public partial class UserManager 
    {
    
        const int MaxAttempts = 5;
    
        public LoginStatus ValidateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException("username");
    
            //set the password to empty if it is null
            password = password ?? "";
    
            //create the connection
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                //assign some local variables
                int attemptsLeft = MaxAttempts;
                string currentStatus = "Active";
                string userPassword = null;
    
                //get the information for the user, only query by username so we have all the data. We will match the password later on
                string query = "SELECT TOP(1) [Username], [Password], [AttemptsLeft], [CurrentStatus] FROM [Information] WHERE Username = @username";
    
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.CommandType = System.Data.CommandType.Text;
    
                    connection.Open();
    
                    using (var reader = command.ExecuteReader())
                    {
                        //no rows.. Invalid username
                        if (!reader.HasRows)
                        {
                            connection.Close();
                            return LoginStatus.InvalidCredentials;
                        }
    
                        //read the first row (hence the break)
                        while (reader.Read())
                        {
                            attemptsLeft = (int)reader["AttemptsLeft"];
                            currentStatus = (string)reader["CurrentStatus"];
                            userPassword = (string)reader["Password"];
                            break;
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
    
                //if the account is suspended then dont even bother with password checking
                if (currentStatus.Equals("Suspended", StringComparison.CurrentCultureIgnoreCase))
                {
                    return LoginStatus.Suspended;
                }
    
                //invalid password lets handle the invalid credentials logic
                if (!password.Equals(userPassword))
                {
                    attemptsLeft -= 1;
    
                    //decrease the attempts, lets just stop at zero as we dont need negative attempts
                    if(attemptsLeft >= 0)
                    {
                        query = "UPDATE [Information] SET [AttemptsLeft] = @attemptsLeft WHERE Username = @username";
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@username", username);
                            command.Parameters.AddWithValue("@attemptsLeft", attemptsLeft);
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
    
                    //suspend the account when attempts less than or equal to zero
                    if (attemptsLeft <= 0)
                    {
                        query = "UPDATE [Information] SET [CurrentStatus] = @currentStatus WHERE Username = @username";
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@username", username);
                            command.Parameters.AddWithValue("@currentStatus", "Suspended");
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                        //exit method as login account suspended
                        return LoginStatus.Suspended;
                    }
    
                    //exit as invalid login credentials
                    return LoginStatus.InvalidCredentials;
                }
                //if we are here lets quickly reset the login attempts back to 5, and account status to active as this is a valid login
                query = "UPDATE [Information] SET [AttemptsLeft] = @attemptsLeft, [CurrentStatus] = @currentStatus WHERE Username = @username";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@attemptsLeft", MaxAttempts);
                    command.Parameters.AddWithValue("@currentStatus", "Active");
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                //if we got here then every thing is a match
                return LoginStatus.Authorized;
            }
        }
    
    }
    
    public enum LoginStatus
    {
        Authorized,
        InvalidCredentials,
        Suspended
    }
