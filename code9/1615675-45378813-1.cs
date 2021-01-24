	protected void ButtonClick(object sender, EventArgs e)
	{
		using (var sqlConnection1 = new SqlConnection("data source=testServer;initial catalog=testCat;integrated security=True;"))
		using (var insertData = new SqlCommand("insert into tempExample (id, code, description) values ((select max(coalesce(id, 1)) from tempExample)+1, @code, @description)", sqlConnection1))
		{
			insertData.CommandType = CommandType.Text;
			insertData.Parameters.AddWithValue("@code", "Testing4");
			insertData.Parameters.AddWithValue("@description", "Testing3");
			sqlConnection1.Open();
			insertData.ExecuteNonQuery();
			sqlConnection1.Close();
		}
	}
