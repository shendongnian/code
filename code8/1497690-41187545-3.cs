    IEnumerable<YourType> listOfId1;
    IEnumerable<YourType> listOfId2;
    
    using (var connection = new SqlConnection(someConnectionString))
    using (var command = new SqlCommand(someStoreProcedureName, connection))
    {
    	connection.Open();
    	command.CommandType = CommandType.StoredProcedure;
    
    	using (var reader = command.ExecuteReader())
    	{
    		var combinedList = reader.Cast<IDataRecord>()
    								 .ToList()
    								 .Select(dataRecord =>
    								 new YourType()
    								 {
    									 VersionNumber = dataRecord.GetInt32(dataRecord.GetOrdinal("VersionNumber")),
    									 Id = dataRecord.GetInt32(dataRecord.GetOrdinal("Id")),
    									 FromType = dataRecord.GetString(dataRecord.GetOrdinal("FromType")),
    									 FromStatusId = dataRecord.GetString(dataRecord.GetOrdinal("FromStatusId"))
    								 });
    								 
    		listOfId1 = combinedList.Where(item => item.Id == 111111).ToList();
    		listOfId2 = combinedList.Where(item => item.Id == 222222).ToList();
    	}
    }
