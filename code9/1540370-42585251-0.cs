        protected void loginbutton_Click(object sender, EventArgs e)
        {
            string UsernameRegex = "[a-zA-Z]+";
            string PasswordRegex = "[a-zA-Z0-9]+";
            var userName = usernametextbox.Text;
            var password = passwordtextbox.Text;
            if (!Regex.IsMatch(userName, UsernameRegex))
            {
                // do something
                return; // There is no need to go on
            }
            
            if(!Regex.IsMatch(password, PasswordRegex))
            {
                // do something
                return; // There is no need to go on
            }
            //If we can come here, we can go DB
            // To be dispose when the job is done
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                
                try
                {
                    // To be dispose when the job is done
                    using (SqlCommand com = new SqlCommand(checkuser, conn))
                    {
                        conn.Open();
                        string checkuser = "select count(*) from Users where Username = @username and Password = @password";
                        com.Parameters.Add("@username", SqlDbType.NVarChar).Value = userName;
                        com.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
                        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                        if (temp > 0)
                        {
                            Response.Redirect("Cars.aspx");
                        }
                        else
                        {
                            loginfaillabel.Text = "Your Username or Password doesn't match our records";
                        }
                    }
                }
                catch (Exception ex)
                {
                    // you can handle error. maybe logs
                }
            }
        }
