    string query1 = "SELECT photo,name FROM Artist";
	using(var conn = new SqlConnection("connectionStringHere"))
	using(SqlCommand cmd = new SqlCommand(query1, conn))
	{
		conn.Open();
		using(SqlDataReader reader = cmd.ExecuteReader())
		{
			while(reader.Read())
			{
				byte[] bytes = (byte[])reader.GetValue(0);
				string strBase64 = Convert.ToBase64String(bytes);
			
				ImageButton imgButton = new ImageButton();
				imgButton.ImageUrl = "data:Image/png;base64," + strBase64;
				imgButton.Width = Unit.Pixel(200);
				imgButton.Height = Unit.Pixel(200);
				imgButton.Style.Add("padding", "5px");
				imgButton.Click += new ImageClickEventHandler(imgButton_Click);
				Panel1.Controls.Add(imgButton);
				
				Label lbl = new Label();
				lbl.Text = reader.GetString(1); // use GetString, not GetValue here
				lbl.CssClass = "imageLable"; // style it in your .css file
				Panel1.Controls.Add(lbl);
			}
		}
	}
