    using System.Data.SqlClient;
    
    protected void Button1_Click(object sender, EventArgs e)
    {
    SqlConnection con = new SqlConnection(System.Configuration.
    ConfigurationManager.ConnectionStrings["con"].ToString());
    	try
    	{
    		string query = "insert into UserDetail(Name,Address) 
    		values('" + txtName.Text + "','" + txtAddress.Text + "');";
    		SqlDataAdapter da = new SqlDataAdapter(query, con);
    		con.Open();
    		da.SelectCommand.ExecuteNonQuery();
    		con.Close();
    		lblmessage.Text = "Data saved successfully.";
    	}
    	catch
    	{
    		con.Close();
    		lblmessage.Text = "Error while saving data.";
    	}
    
    }
