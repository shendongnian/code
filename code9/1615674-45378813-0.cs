	protected void ButtonClick(object sender, EventArgs e)
	{
		using (var sqlConnection1 = new SqlConnection("Data Source=SERVER; Initial Catalog = Metal; Integrated Security = True"))
		using (var insertData = new SqlCommand("INSERT INTO ApptIn (CONTROLNUMBER, CARRIERNAME, EXPECTEDNUMOFPIECES, EXPECTEDWEIGHT) VALUES ((SELECT MAX(CONTROLNUMBER) FROM ApptIn) +1,@carrierSelectInput, @pieceCountInput, @weightinput)", sqlConnection1))
		{
			insertData.CommandType = CommandType.Text;
			insertData.Parameters.AddWithValue("@carrierSelectInput", DropDownList1.Text);
			insertData.Parameters.AddWithValue("@pieceCountInput", TextBox1.Text);
			insertData.Parameters.AddWithValue("@weightInput", TextBox2.Text);
			sqlConnection1.Open();
			insertData.ExecuteNonQuery();
			sqlConnection1.Close();
		}
	}
