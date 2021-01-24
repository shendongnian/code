     using (var cmd = new NpgsqlCommand("SELECT * FROM Persons", conn))
     {
     using (var reader = cmd.ExecuteReader())
     {
    	 var columns = new List<string>();
    	 for(int i=0;i<reader.FieldCount;i++)
    		columns.Add(reader.GetName(i));
    
    	JsonArrayCollection jsonArray = new JsonArrayCollection();
    	 while (reader.Read())
    	{   
    		JsonObjectCollection jsonObject = new JsonObjectCollection();
    		for(string columnName in columns)
    			jsonObject.Add(new JsonStringValue(columnName, reader[columnName]));
    		jsonArray.Add(jsonObject);
    	}
     }
    }
