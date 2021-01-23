    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Stock.accdb";
	using (SqlConnection connection = new SqlConnection(connectionString))
	{
	    connection.Open();
	    using (SqlCommand command = new SqlCommand(
		"SELECT * FROM product WHERE product_ref LIKE '%@value%'", connection))
	    {
		    command.Parameters.Add(new SqlParameter("value", textBox_ref.Text.Trim()));
		    SqlDataReader reader = command.ExecuteReader();
		    while (reader.Read())
		    {
		        // Do whatever you want to do with the queried data
		    }
	    }
	}
