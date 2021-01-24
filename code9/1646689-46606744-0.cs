	protected void Button2_Click(object sender, EventArgs e)
	{
		var connStr = ConfigurationManager.ConnectionStrings["AdventureWorks2014ConnectionString"].ConnectionString;
		using (var cnn = new SqlConnection(connStr)) {
			cnn.Open();
			
			var cmd = cnn.CreateCommand();
			cmd.CommandText = "Insert into users (FirstName,LastName,Gender) Values (@Name,@Surname,@Gender)";
			cmd.Parameters.AddWithValue("@Name", TextBox3.Text);
			cmd.Parameters.AddWithValue("@Surname", TextBox4.Text);
			cmd.Parameters.AddWithValue("@Gender", TextBox5.Text);
			
			var affectedRows = cmd.ExecuteNonQuery();
			//	Do validation here.
			//	This should be 1, the number of rows inserted.
		}
		
		if (IsPostBack)
			TextBox3.Text = TextBox4.Text = TextBox5.Text = string.Empty;		
	}
