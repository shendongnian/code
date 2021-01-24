	string sqlQuery = "SELECT tuition_fee FROM Tuition WHERE tuition_code = @tuitionCode";
	using (var con = new SqlConnection(_connectionstring))
	{
		con.Open();
		using (var cmd = new SqlCommand(sqlQuery, con))
		{
			cmd.Parameters.AddWithValue("@tuitionCode", studenttuition_code);
			using (var dr = cmd.ExecuteReader())
			{
				dr.Read();
				lblAmount.Text = dr.GetString(0);
			}
		}
		con.Close();
	}
