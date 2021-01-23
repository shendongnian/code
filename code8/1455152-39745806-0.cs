    protected void Button1_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(@"Data Source=LP12;Initial Catalog=SmmsData;Integrated Security=True");
			con.Open();
			SqlCommand cmd = new SqlCommand("Select DrukSensor,DateTime from SysteemSensorInfo2", con);
			SqlDataReader myreader;
			DataSet ds = new DataSet();
			new SqlDataAdapter(cmd).Fill(ds);
			myreader = cmd.ExecuteReader();
			Chart1.Series.Add("DrukSensor"); // Add this line
			Chart1.Series["DrukSensor"].Points.AddXY(myreader.GetDateTime(Int32.Parse("DateTime")), myreader.GetFloat(Int32.Parse("DrukSensor")));
			Chart1.DataSource = ds;
			Chart1.DataBind();
		}
