    using (SqlConnection con = new SqlConnection(connectionString))
    {
        con.Open(); 
    	SqlDataAdapter sda = new SqlDataAdapter("Select * from Info where RegistrationID = '" + RegistrationID.Text + "'", con); 
    	DataTable dt = new DataTable(); 
    	sda.Fill(dt); 
    	if (dt != null && dt.Rows.Count() > 0)
    	{
    		RegistrationID.Text = dt.Rows[0][0].ToString(); 
    		Date.Text = dt.Rows[0][1].ToString(); 
    		Name.Text = dt.Rows[0][2].ToString(); 
    		Gender.Text = dt.Rows[0][3].ToString(); 
    		ContactNumber.Text = dt.Rows[0][4].ToString(); 
    	}
    	else
    	{
    		MessageBox.Show("Data does not exist!!!");
    	}
    }
