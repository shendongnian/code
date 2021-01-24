	protected void loginbutton_Click(object sender, EventArgs e)
	{
		string UsernameRegex = "[a-zA-Z]+";
		string PasswordRegex = "[a-zA-Z0-9]+";
		boolean isUsernameValid = Regex.IsMatch(usernametextbox.Text, UsernameRegex)
		boolean isPasswordValid = Regex.IsMatch(passwordtextbox.Text, PasswordRegex);
		if(!isUsernameValid || !isPasswordValid) //i will include password here after i solved the problem
		{
			//do something
		}
		else
		{
			const string checkuser = "SELECT 1 FROM Users WHERE Username = @username and Password = @password";
			using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
			using(SqlCommand com = new SqlCommand(checkuser, conn))
			{
				conn.Open();
				
				com.Parameters.Add("@username", SqlDbType.NVarChar).Value = usernametextbox.Text;
				com.Parameters.Add("@password", SqlDbType.NVarChar).Value = passwordtextbox.Text;
				object temp = com.ExecuteScalar();
				
				// I do not remember if it is null or System.DbNull.Value that is returned if nothing is returned
				// you will have to test it
				var didUserMatch = temp == null || temp == System.DbNull.Value ? false : true;
				if (didUserMatch)
				{
					Response.Redirect("Cars.aspx");
				}
				else
				{
					loginfaillabel.Text = "Your Username or Password doesn't match our records";
				}
			}
		}
	}
