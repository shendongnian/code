    public ItemCategory GetThisItemCategory(int ItemCategoryCode = -1, string SupplierCode = "", string ItemCategory = "")
    {
    
    	using (SqlCommand cmd = new SqlCommand("MyConnectionString")
    	{
    
    		/* TO DO !!! , build your sql-string and parameter list here */
    
    		using (IDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
    		{
    
    			if /*while*/ (dataReader.Read())
    			{
    				ic.ItemCategoryCode = dr.GetInt32(0);
    				ic.SupplierCode = dr.GetString(1);
    				ic.ItemCategoryName = dr.GetString(2);
    				ic.OrderableStockLimit = (dr.IsDBNull(3)) ? -1 : dr.GetInt32(3);
    			}
    
    			if (dataReader != null)
    			{
    				try
    				{
    					dataReader.Close();
    				}
    				catch { }
    			}           
    
    		}
    		
    		cmd.Close();
    		
    	}
    
        return ic;
    
    }
