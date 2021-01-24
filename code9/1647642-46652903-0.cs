    private void suggestComboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
    {
    	try
    	{
    		string connectionString = "Data Source=bid;Initial Catalog=BI_ST;Integrated Security=True";
    		string query = "SELECT * FROM dbo.IV00 WHERE ITEMNMBR = @itemnmbr;";
    		using (SqlConnection con = new SqlConnection(connectionString))
    		{
    			using (SqlCommand cmd = con.CreateCommand())
    			{
    				cmd.CommandText = query;				
    				var parItemNmbr = cmd.Parameters.Add("@itemnmbr", SqlDbType.Int);
    				parItemNmbr.Value = suggestComboBox2.SelectedValue;
    				con.Open();
    				
    				SqlDataReader dr = cmd.ExecuteReader();
    				dr.Read();
    
    				string cari_code = dr.GetString(dr.GetOrdinal("ITEMNMBR"));
    				textBox2.Text = cari_code;
    
    				string intFromSmallInt = Convert.ToString(dr.GetInt16(dr.GetOrdinal("ITEMTYPE")));
    				textBox12.Text = intFromSmallInt;
    			}		
    		}
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.ToString());
    	}
    }
