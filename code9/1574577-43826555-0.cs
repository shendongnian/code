    public void RegisterUser(string fName, string lName, string email, string password)
        {
            string conStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
    
            using (SqlConnection openCon = new SqlConnection(conStr))
            {
                string saveUser = "INSERT into Users (firstName,lastName,email,password,isAdmin) VALUES (@firstName,@lastName,@email,@password,@isAdmin)";
    
                using (SqlCommand querySaveUser = new SqlCommand(saveUser))
                {
                    querySaveUser.Connection = openCon;
                    querySaveUser.Parameters.AddWithValue("@firstName", fName);
                    querySaveUser.Parameters.AddWithValue("@lastName", lName);
                    querySaveUser.Parameters.AddWithValue("@email", email);
                    querySaveUser.Parameters.AddWithValue("@password", password);
                    querySaveUser.Parameters.AddWithValue("@isAdmin", 1);
                    openCon.Open();
                    querySaveUser.ExecuteNonQuery();
                }
            }
        }
