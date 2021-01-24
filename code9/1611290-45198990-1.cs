		DataTable dt; //declared outside a method so that multiple methods have access to it object.
		private void Form1_Load(object sender, EventArgs e)
		{
			//Some other area where the datagridview is populated with more information
			SqlConnection con = new SqlConnection(@"MyConnectionString");
			con.Open();
			SqlDataAdapter sda = new SqlDataAdapter("SELECT FirstName, LastName, Address, State FROM Employee", con);
			dt = new DataTable();
			sda.Fill(dt);
			dataGridView1.DataSource = dt;
		}
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			//all that should be needed to filter the datagridview to your condition
        	dt.DefaultView.RowFilter = string.Format("FirstName LIKE '%{0}%'", textBox1.Text);
		}
