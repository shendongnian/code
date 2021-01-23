	try 
	{
		using (SqlCommand cmd = new SqlCommand("INSERT INTO Property ( FolioNo,PropertyType) VALUES (001,'WIP')"))
		{
			cmd.Connection = con;
			con.Open();
			if (cmd.ExecuteNonQuery() > 0)
			{
				MessageBox.Show("Record inserted");
			}
			else
			{
				MessageBox.Show("Record failed");
			}
		}
	}
	catch (Exception g)
	{
		MessageBox.Show("Error during insert: " + g.Message);
	}
