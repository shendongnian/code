      		Data.con.Open();
		string SaveStr = "Insert into tblOrder (CustomerID, CustomerName, CustomerAdd, Date, Orders, TotalPrice) Values (@CustomerID, @CustomerName, @CustomerAdd, @Date, @Orders, @TotalPrice)";
		SqlCommand SaveCmd = new SqlCommand(SaveStr, Data.con);
		SaveCmd.Parameters.AddWithValue("@CustomerID", textBox4.Text);
		SaveCmd.Parameters.AddWithValue("@CustomerName", textBox5.Text);
		SaveCmd.Parameters.AddWithValue("@CustomerAdd", textBox6.Text);
		SaveCmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
		SaveCmd.Parameters.AddWithValue("@Orders", String.Join("," , listBox1.Items.OfType<string>().ToArray());
         ));
		SaveCmd.Parameters.AddWithValue("TotalPrice", textBox3.Text);
		SaveCmd.ExecuteNonQuery();
		Data.con.Close();
		LoadData();
       
