    IEnumerable<IEnumerable<YourType>> yourListOfLists;
    
    using (var connection = new SqlConnection(someConnectionString))
    using (var command = new SqlCommand(someStoreProcedureName, connection))
    {
    	connection.Open();
    	command.CommandType = CommandType.StoredProcedure;
    
    	using (var reader = command.ExecuteReader())
    	{
    		yourListOfLists = reader.Cast<IDataRecord>()
    								 .ToList()
    								 .Select(dataRecord =>
    								 new YourType()
    								 {
    									 VersionNumber = dataRecord.GetInt32(dataRecord.GetOrdinal("VersionNumber")),
    									 Id = dataRecord.GetInt32(dataRecord.GetOrdinal("Id")),
    									 FromType = dataRecord.GetString(dataRecord.GetOrdinal("FromType")),
    									 FromStatusId = dataRecord.GetString(dataRecord.GetOrdinal("FromStatusId"))
    								 })
    								 .GroupBy(youObject => youObject.Id)
    								 .Select(group => group.ToList())
    								 .ToList();
    	}
    }
