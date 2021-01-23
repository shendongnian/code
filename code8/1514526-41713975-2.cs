    private Roles validate_login(string user, string pass)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from loginsignupdata where username=@username and password=@password";
            cmd.Parameters.AddWithValue("@username", user);
            cmd.Parameters.AddWithValue("@password", pass);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                connect.Close();
                // return true;
                // Instead of returning true, return the role of the user
            }
            else
            {
                connect.Close();
                // return false;
                // Instead of returning false, throw an exception, or reserve an enum for failed logins
            }
        }
