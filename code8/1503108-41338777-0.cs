	private void btnSave_Click(object sender, RoutedEventArgs e)
	{
		using (SqlConnection con = new SqlConnection())
		{
			con.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
			con.Open();
			using (SqlCommand cmd = new SqlCommand("uspINSERT", con))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
				//.....some code
			}
		}
	}
	
	private void bindDataGrid()
	{
		using (SqlConnection con = new SqlConnection())
		{
			con.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
			con.Open();
			using (SqlCommand cmd = new SqlCommand("uspSELECTALL", con))
			{
				cmd.Connection = con;
				//...some code
			}
		}
	}
