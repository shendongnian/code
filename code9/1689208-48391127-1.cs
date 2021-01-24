    private void button3_Click(object sender, EventArgs e)
    {
    	try
    	{
    		if (string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(textBox8.Text))
    		{
    			MessageBox.Show("Please Fill The Required Fields To Find Data !!");
    		}
    		else
    		{
    			using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
    			{
    				conn.Open();
    
    				using (SqlCommand cmd = new SqlCommand("bookdat_Search", conn))
    				{
    					cmd.CommandType = System.Data.CommandType.StoredProcedure;
    					switch (comboBox2.SelectedIndex)
    					{
    						case 1:
    							cmd.Parameters.Add("@title", SqlDbType.VarChar, 50).Value = textBox8.Text;
    							break;
    						case 2:
    							cmd.Parameters.Add("@author", SqlDbType.VarChar, 50).Value = textBox8.Text;
    							break;
    						case 3:
    							cmd.Parameters.Add("@publication", SqlDbType.VarChar, 50).Value = textBox8.Text;
    							break;
    						case 4:
    							cmd.Parameters.Add("@accno", SqlDbType.Int).Value = int.Parse(textBox8.Text);
    							break;
    						case 5:
    							cmd.Parameters.Add("@price", SqlDbType.Int).Value = int.Parse(textBox8.Text);
    							break;
    						case 6:
    							cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = int.Parse(textBox8.Text);
    							break;
    					}
    					using (SqlDataReader reader = cmd.ExecuteReader())
    					{
    						if (reader.Read())
    						{
    							MessageBox.Show("Record Found!!");
    						}
    						else
    						{
    							MessageBox.Show("No Record Found!!");
    						}
    					}
    				}
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.ToString());
    	}
    }
