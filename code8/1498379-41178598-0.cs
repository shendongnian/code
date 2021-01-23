	using (SqlConnection connection = new SqlConnection(@"Data Source=HO-IT-049;Initial Catalog=Estatment;Integrated Security=True"))
	{
		sqlq = "Select * from Registration WHERE " + ddl1.SelectedItem.Text + " = @paramdata";
		connection.Open();
		using (SqlCommand cmd = new SqlCommand(sql, connection))
		{
			//Have a look at the DataType in the Database
			cmd.Parameters.Add("@paramdata",SqlDbType.Varchar, 50).value = ddl1.SelectedItem.Value;
			using (SqlDataAdapter da = new SqlDataAdapter(cmd, connection))
			{
				DataTable dt = new DataTable();
				da.Fill(dt);
			}
		}
	}
