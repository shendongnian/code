    using(SqlDataReader imageReader = selectSingleImageCommand.ExecuteReader(CommandBehavior.SequentialAccess))
    {
    	if (imageReader.Read())
    	{
    		using (Stream backendStream = imageReader.GetStream(0))
            {
    			//Do whater you need with the Stream
    		}
    	}	
    }
