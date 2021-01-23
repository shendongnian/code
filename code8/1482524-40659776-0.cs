	protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
	{
		var conString = ConfigurationManager.ConnectionStrings["CONSTRING"].ConnectionString;
		SqlConnection con = new SqlConnection(conString);
		string user = Login1.UserName;
		string pass = Login1.Password;
		con.Open();
		SqlCommand cmd1 = new SqlCommand("select username, password, status from login where username = '" + user + "' and password = '" + pass + "' and status = 1", con);
		string CurrentName;
		CurrentName = (string)cmd1.ExecuteScalar();
		if (CurrentName != null)
		{
			
			Session.Timeout = 1;
			Session["un"] = Login1.UserName;
			Response.Redirect("sellerlogin.aspx?un=" + Login1.UserName);
			Response.End();
			return;
		}
		SqlCommand cmd2 = new SqlCommand("select username, password, status from dealer where username = '" + user + "' and password = '" + pass + "' ", con);
		
		string CurrentNam;
		CurrentNam = (string)cmd2.ExecuteScalar();
		if (CurrentNam != null)
		{
			Session.Timeout = 1;
			Response.Redirect("dealerlogin.aspx?un="+ Login1.UserName);
			Response.End();
			return;
		}
