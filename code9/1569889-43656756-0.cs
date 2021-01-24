    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    string query = "select Username from [Login] WHERE Username='"+((TextBox)DetailsView1.FindControl("TextBox1")).Text+"'";
    SqlCommand cmd = new SqlCommand(query);
	SqlDataReader reader = cmd.ExecuteReader();
	if(reader.HasRows())
	{
	// The username exist
	}
