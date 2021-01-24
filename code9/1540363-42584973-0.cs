    protected void loginbutton_Click(object sender, EventArgs e)
		{
			string UsernameRegex = "[a-zA-Z]+";
			string PasswordRegex = "[a-zA-Z0-9]+";
			bool UsernameCheck = false; // better name for this is isUsernameValie
			if (!Regex.IsMatch(usernametextbox.Text, UsernameRegex))
			{
				UsernameCheck = true;
			}
			else
			{
				UsernameCheck = false;
			}
			bool PasswordCheck = false;// better name for this is isPasswordValid
			if (!Regex.IsMatch(passwordtextbox.Text, PasswordRegex))
			{
				 PasswordCheck = true;
			}
			else
			{
				PasswordCheck = false;
			}
			if (UsernameCheck == true) //i will include password here after i solved the problem
			{
				//do something
			}
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
			conn.Open();
			string checkuser = "select count(*) from Users where Username = @username and Password = @password";
			SqlCommand com = new SqlCommand(checkuser, conn);
			com.Parameters.Add("@username", SqlDbType.NVarChar).Value = usernametextbox.Text;
			com.Parameters.Add("@password", SqlDbType.NVarChar).Value = passwordtextbox.Text;
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
