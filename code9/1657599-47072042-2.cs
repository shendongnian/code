    private bool AuthenticateUser(string username, string password)
    {
        string CS = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        using (SqlConnection Conn = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SP_AuthenticateUser", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            string EncryptPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
            SqlParameter paramUserName = new SqlParameter("@UserName", username);
            SqlParameter paramPassword = new SqlParameter("@Password", EncryptPassword);
            cmd.Parameters.Add(paramUserName);
            cmd.Parameters.Add(paramPassword);
            Conn.Open();
            var reader = cmd.ExecuteReader();
            reader.Read();
            return reader["Authenticate"] as bool;
        }
    }
