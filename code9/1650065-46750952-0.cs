    public bool AuthenticateUser(UserLogin userLogin)
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            var result = false;
            SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            string encryptedpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(userLogin.Password, "SHA1");
            SqlParameter paramUsername = new SqlParameter("@UserName", userLogin.Username);
            SqlParameter paramPassword = new SqlParameter("@Password", encryptedpassword);
            cmd.Parameters.Add(paramUsername);
            cmd.Parameters.Add(paramPassword);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int RetryAttempts = Convert.ToInt32(rdr["RetryAttempts"]);
                if (Convert.ToBoolean(rdr["AccountLocked"]))
                {
                    result = false;
                }
                else if (RetryAttempts > 0)
                {
                    int AttemptsLeft = (4 - RetryAttempts);
                    result = true;
    
                }
    
                else if (Convert.ToBoolean(rdr["Authenticated"]))
                {
                    result = true;
                }
    
            }
            return result;
        }
    } 
                   
