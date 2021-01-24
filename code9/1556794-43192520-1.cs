    string userNameLogin = string.Empty;
    using(SqliteConnection conn = new SqliteConnection("Data Source=BBUser.sqlite;Version=3;"))
    using(SqliteCommand command = new SqliteCommand(@"SELECT UserName 
            FROM T_test WHERE UserName=@UserName AND Password=@Password", conn))
    {
            command.Parameters.AddWithValue ("@UserName", txtUserName.Text);
            command.Parameters.AddWithValue ("@Password", txtPassword.Text);
            conn.Open ();
            result = command.ExecuteScalar();
    }
    if(string.IsNullOrEmpty(result))
    {
        // Failure
    }
    else
    {
        // Success
    }
