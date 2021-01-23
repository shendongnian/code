	string model=String.Empty;
	int price = 0;
	string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True";
	using (SqlConnection con2 = new SqlConnection(connectionString))
	{
		try
		{
			con2.Open();             
			using(SqlCommand command = new SqlCommand())
			{
				command.Connection = con2;
				command.CommandText = string.Format("update Inventory set Quantity = Quantity - @qty WHERE id=@id";
				command.Parameters.AddWithValue("@id", tbItemid.Text);
				command.Parameters.AddWithValue("@qty", Convert.ToInt32(tbQuantity.Text)));
				command.ExecuteNonQuery();
				Data();
				DData();
				int x = int.Parse(tbQuantity.Text);
				using(SqlCommand cmd1 = new SqlCommand("SELECT Model, Price from Inventory WHERE id=@id"))
				{
					cmd1.Parameters.AddWithValue("@id", tbItemid.Text);
					SqlDataReader modelRdr = null;
					modelRdr = cmd1.ExecuteReader();
					modelRdr.Read();
					model = modelRdr["model"].ToString();
					price = int.Parse(modelRdr["Price"].ToString());	
				}
				using(SqlCommand cmd = con.CreateCommand())
				{
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "insert into Bill values (@id,@model,@price,@qty)";.
					cmd.Parameters.AddWithValue("@id", tbItemid.Text);
					cmd.Parameters.AddWithValue("@model", model);
					cmd.Parameters.AddWithValue("@price", price);
					cmd.Parameters.AddWithValue("@qty", tbQuantity.Text);
					cmd.ExecuteNonQuery();
				}
				Data();
			}
			catch
			{
				MessageBox.Show("Enter Catagory and Product ID");
			}
		}
	}
