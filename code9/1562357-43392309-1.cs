    private void GetPassengerList()
    {
    	string sPassenger = textBoxPassengerName.Text;
    	if (sPassenger.Trim().Length > 0)
    	{
    		string sSqlSelect = @"SELECT Passenger FROM ";
		    string sSqlWhere = @" WHERE (Created BETWEEN @startDate AND @endDate)";
    		// I assume this is looking for passenger. Change appropriately.
            string sSqlLike = @"AND Passenger LIKE @name"; 
    		string searchTerm = "%" + sPassenger + "%";
    
    		SqlDataReader sqlReader = null;
    		try
    		{
    			SqlCommand sqlCommand = new SqlCommand(sSqlSelect + @"dbo.BagData" + sSqlWhere, parentWindow.dbConnection);
    			sqlReader = sqlCommand.ExecuteReader();
    			if (!sqlReader.Read())
    			{
    				sqlReader.Close();
    				sqlCommand.CommandText = sSqlSelect + @"dbo.BagDataHistory" + sSqlWhere + sSqlLike;
    				sqlCommand.Parameters.Add(new SqlParameter("@name", searchTerm));
				    sqlCommand.Parameters.Add(new SqlParameter("@startDate", yourStartDateVariable));
				    sqlCommand.Parameters.Add(new SqlParameter("@endDate", yourEndDateVariable));
    				sqlReader = sqlCommand.ExecuteReader();
    				if (!sqlReader.Read())
    				{
    					sqlReader.Close();
    					sqlCommand.CommandText = sSqlSelect + @"dbo.BagDataArchive" + sSqlWhere + sSqlLike;
    					sqlReader = sqlCommand.ExecuteReader();
                        
                        // This will loop through your returned data and add
                        // an item to a list view (listView1) for each row.
    					while (sqlReader.Read())
    					{
    						ListViewItem lvItem = new ListViewItem();
    						lvItem.SubItems[0].Text = sqlReader[0].ToString();
    						lvItem.SubItems.Add(sqlReader[0].ToString());
    						listView1.Items.Add(lvItem);
    					}
    					sqlReader.Close();
    				}
    			}
    			if (!sqlReader.IsClosed)
    			{
    				sPassenger = parentWindow.GetSqlDataString(@"Passenger", sqlReader);
    				sqlReader.Close();
    			}
    		}
    		catch (SqlException x)
    		{
    			MessageBox.Show(@"GetPassengerName(): SQL Exception: " + x.Message, parentWindow.GetHashString("Error"), MessageBoxButton.OK, MessageBoxImage.Error);
    		}
    		catch (Exception ex)
    		{
    			MessageBox.Show(@"GetPassengerName(): General Exception: " + ex.Message, parentWindow.GetHashString("Error"), MessageBoxButton.OK, MessageBoxImage.Error);
    		}
    		finally
    		{
    			if (sqlReader != null)
    			{
    				if (!sqlReader.IsClosed)
    				{
    					sqlReader.Close();
    				}
    			}
    		}
    	}
    }
