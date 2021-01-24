    int _failedAttempt = 0;
    public void Userlogin(TextBox username, TextBox pwd)
    {
      try
      {
        using (var connection = new OracleConnection(_connectionString))
        {
          connection.Open();
          using (var command = new OracleCommand())
          {
            command.CommandText = "SELECT username, user_pwd FROM dinein_system_users WHERE username:usrname AND user_pwd:pwd";
            command.Connection = connection;
            command.BindByName = true;
            command.Parameters.Add("usrname", username.Text);
            command.Parameters.Add("pwd", pwd.Text);
            using (var reader = command.ExecuteReader())
            {
              if (reader.Read() != true)
              {
                _failedAttempt += 1;
                if (_failedAttempt < 3)
                {
                  MessageBox.Show("Incorrect Username or Password. " +
                                  "Please try again. " + 
                                  $"Attempts: {_failedAttempt}");
                  username.ResetText();
                  pwd.ResetText();
                }
                else
                {
                  // 3 failed attempts
                }
              }
              else
              {
                _failedAttempt = 0;
                MessageBox.Show("Welcome");
              }
            }
          }
        }
      }
      catch(OracleException ex)
      {
        MessageBox.Show("Error: {ex}");
      }
    }
