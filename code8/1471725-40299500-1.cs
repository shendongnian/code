	string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
	using (SqlConnection connection = new SqlConnection(cs)) using (SqlCommand cmd = connection.CreateCommand())
	{ 
		cmd.CommandText = "Update tblProduct SET UnitPrice =@paramunitprice WHERE ProductName = @paramproductname";
		con.Open();
		for (int i = 0; i < this.Controls.Count; i++)
		{
			if (this.Controls[i] is TextBox)
			{
				TextBox myTextbox = (TextBox)this.Controls[i];
				string txtvalue = myTextbox.Text;
				string lblvalue = //The Corresponding Label value to find which UnitPrice has to change.
				cmd.Parameters.AddWithValue("@paramunitprice", txtvalue);
				cmd.Parameters.AddWithValue("@paramproductname", lblvalue);
				
				cmd.ExecuteNonQuery();
			}
		}
	}
