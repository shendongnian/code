    public bool Insert(Picture entity)
    {
    	var command = new SqlCommand();
    
    	try
    	{
    		command.CommandText = "AddPicture";
    		command.CommandType = CommandType.StoredProcedure;
    
    		command.Parameters.AddWithValue("@Name", entity.Name).Direction = ParameterDirection.Input;
    		command.Parameters.AddWithValue("@Photo", entity.Photo).Direction = ParameterDirection.Input;
    
    		int result = SqlHelper.ExecuteNonQuery(command); //executenonquery will save the params to the db
    
    		return true;
    	}
    	catch (Exception)
    	{
    		return false;
    	}
    }
