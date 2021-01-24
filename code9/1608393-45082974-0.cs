    // define the list
    var values = new List<Dictionary<string, object>>();
    try
    {
    	connection.Open();
        // Use the using block to make sure you are disposing the dataReader object.
    	using (SqlDataReader reader = command.ExecuteReader())
    	{
    		do
    		{    			
    			while (reader.Read())
    			{
                    // define the dictionary
    				var fieldValues = new Dictionary<string, object>();
    				
    				// fill up each column and values on the dictionary    				
                    for (int i = 0; i < reader.FieldCount; i++)
    				{
    					fieldValues.Add(reader.GetName(i), reader[i]);
    				}
    				
    				// add the dictionary on the values list
    				values.Add(fieldValues);
    				
    			}
    		} while (reader.NextResult());	 // if you have multiple result sets on the Stored Procedure, use this. Otherwise you could remove the do/while loop and use just the while.
    	}
    }
    catch (Exception ex)
    {
    	System.Diagnostics.Debug.WriteLine("oops");
    }
