    using System.Data.SqlClient;
    ...
    
    string conStr = ConfigurationManager.ConnectionStrings["MembersConnectionString"].ConnectionString;
    string sql = "SELECT * FROM Members where Username = @user and Password = @pass";
    SqlParameter pUser = new SqlParameter("@user", TextBoxSignUser.Text);
    SqlParameter pPass = new SqlParameter("@pass", TextBoxSignPass.Text);
    using (SqlConnection con = new SqlConnection(conStr))
    {
        using (SqlCommand cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.Add(pUser);
            cmd.Parameters.Add(pPass);
    
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Successfully signed in
                    // Also you can access your fields' value using:
                    //    1. its index (e.x. reader[0])
                    //    2. or its name: (e.x. reader["Username"])
                }
                else
                {
                    // Login failed
                }
            }
        }
    }
