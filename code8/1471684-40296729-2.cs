	string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
	using (SqlConnection con = new SqlConnection(cs))
	{
		//string cmText = "select ProductId,ProductName,UnitPrice from tblProductInventory";
		string cmText = "Select Count(ProductId) from tblProductInventory";
		SqlCommand cmd = new SqlCommand(cmText, con);
		con.Open();
		Int32 count = (Int32) cmd.ExecuteScalar();
		cmText = "select ProductId,ProductName,UnitPrice from tblProductInventory";
		SqlCommand cmd1 = new SqlCommand(cmText, con);
		using (SqlDataReader rdr = cmd1.ExecuteReader())
		{
			int y = 50;
			Label myLabel = new Label();
			TextBox MyTxt = New TextBox();
			
			while (rdr.Read())
			{
				myLabel = new Label();
				myLabel.Location = new Point(88, y);
				myLabel.Name = "txtVWReadings" + i.ToString();
				myLabel.Size = new Size(173, 20);
				myLabel.TabIndex = i;
				myLabel.Visible = true;
				myLabel.Text = rdr[1].ToString(); //Since you want ProductName here
				y += 25;
				this.Controls.Add(myLabel);
				//Same Way Just include the TextBox
				//After all Position of TextBox 
				MyTxt.Text = rdr[2].ToString(); // I believe you need UnitPrice of the ProductName
			}
		}
	}
