    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {         
            using(var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
            {
                using(var cmd = new SqlCommand("spCheckUsernameForAnswer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@username", TextBoxUN.Text));
                    conn.Open();
                    var returnCode = Convert.ToInt32(cmd.ExecuteScalar());
                    if(returnCode == 1)
                    {
                        Label1.Text = "Username found";
                    }
                    else
                    {
                        Label1.Text = "not found";
                        Register();
                    }
                }
            }               
        }
        catch (Exception ex)
        {
            Response.Write("Error:" + ex.ToString());
        }
    }
    private void RegisterUser()
    {
        try 
    	{
            var newGUID = Guid.NewGuid();
            using(var conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString)
            {
                conn1.Open();
                string insertQuery = "insert into [Users] (user_id, first_name, last_name, email, username, password) values (@user_id, @first_name, @last_name, @email, @username, @password)";
                using(var com = new SqlCommand(insertQuery, conn1))
                {
                    com.Parameters.AddWithValue("@user_id", newGUID.ToString());
                    com.Parameters.AddWithValue("@first_name", TextBoxFname.Text);
                    com.Parameters.AddWithValue("@last_name", TextBoxLname.Text);
                    com.Parameters.AddWithValue("@email", TextBoxEmail.Text);
                    com.Parameters.AddWithValue("@username", TextBoxUN.Text);
                    com.Parameters.AddWithValue("@password", TextBoxPass.Text);
                    com.ExecuteNonQuery();
                }
            }
            Response.Write("Registration successful");
    	}
        catch (Exception exc)
    	{
    		//log the exception;
    	}
    }
