	private void btnSearch_Click(object sender, EventArgs e)
	{
		// use ConnectionString property
		// wrap in using block
		using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDetailConnectionString"].ConnectionString))
		{
			try
			{
				SqlCommand command = new SqlCommand();
				command.Connection = cnn;
				// use parameters
				// avoid *, specify columns instead
				string query = "SELECT * FROM AffiliatedRegister WHERE Username= @userName";
				command.CommandText = query;
				// use parameters, I assumed the parameter type and length - it should be updated to the type and length specified in your table schema
				command.Parameters.Add(new SqlParameter("@userName", SqlDbType.VarChar, 200) {Value = txtUser.Text });
				// open as late as possible
				cnn.Open();
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					// ---[Converting String from db / Insert to textboxes]-- -
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error" + ex); 
				
				// do not swallow the exception unless you know how to recover from it
				throw;
			}
		}
	}
