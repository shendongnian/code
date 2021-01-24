    protected void Button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {     
                SqlCommand command = new SqlCommand("select * from Bidston_HWRC where MCN_No = @MCN", conn);
                conn.Open();
                command.Parameters["@MCN"].Value = Int32.Parse(TextBox17.Text);
                //Execute the query on the server
                SqlDataReader rdr = command.ExecuteReader();
       
         
			if(rdr.HasRows)
			{
			    while (rdr.Read())
				{
                  TextBox6.Text = rdr["Waste_Description"].ToString();
				}
				
				rdr.Close();
			}
			else
			{
			  // show 'no records found'
			}
           conn.Close();
        }
    }
