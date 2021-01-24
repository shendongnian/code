    protected void log_hd_number(int requestID)
    {
      Dictionary<String, String> hdSize = new Dictionary<String, String>();
    
      hdSize.Add("hardDiskSizeData1", hardDiskSizeData1.Text);
      hdSize.Add("hardDiskSizeData2", hardDiskSizeData2.Text);
      hdSize.Add("hardDiskSizeData3", hardDiskSizeData3.Text);
      hdSize.Add("hardDiskSizeData4", hardDiskSizeData4.Text);
      hdSize.Add("hardDiskSizeData5", hardDiskSizeData5.Text);
      hdSize.Add("hardDiskSizeData6", hardDiskSizeData6.Text);
      hdSize.Add("hardDiskSizeData7", hardDiskSizeData7.Text);
      hdSize.Add("hardDiskSizeData8", hardDiskSizeData8.Text);
      hdSize.Add("hardDiskSizeData9", hardDiskSizeData9.Text);
      hdSize.Add("hardDiskSizeData10", hardDiskSizeData10.Text);
    
      int hd = Int32.Parse(hardDiskQuantityData.SelectedValue);
    
      string test2;
    
      for (int i = 1; i <= hd; i++)
      {
    		using(SqlConnection conn = new SqlConnection("Data Source=;Initial Catalog=;Integrated Security=True"))
    		{
    			using(SqlCommand cmd = conn.CreateCommand())
    			{
    				using(SqlDataReader reader)
    				{
    					cmd.CommandType = CommandType.StoredProcedure;
      				    cmd.CommandText = "insert_requested_hd";
    				
    					string test = hdSize["hardDiskSizeData" + i.ToString()];
    					cmd.Parameters.AddWithValue("@hd_size", hdSize["hardDiskSizeData" + i.ToString()]);
    					cmd.Parameters.AddWithValue("@number_requested", hardDiskQuantityData.SelectedValue);
    					cmd.Parameters.AddWithValue("@vm_id", requestID);
    	
    					test2 = " * " + test + " * ";
    	
    					try
    					{
    						conn.Open();
    						reader = cmd.ExecuteReader();
    						reader.Close();
    					}
    					catch (Exception exc)
    					{
    	
    					}
    					finally
    					{
    						if (conn.State != ConnectionState.Closed)
    							conn.Close();
    					}
    				}
    			}
    		}
      }
    }
