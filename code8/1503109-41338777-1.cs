	private SqlConnection MyConnection()
	{
		SqlConnection con = new SqlConnection();
		con.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
		return con;
	}
	
	private void btnSave_Click(object sender, RoutedEventArgs e)
	{
		using (SqlConnection con = MyConnection())
		{
			con.Open();
			using (SqlCommand cmd = new SqlCommand("uspINSERT", con))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
				//.....some code
			}
		}
	}
