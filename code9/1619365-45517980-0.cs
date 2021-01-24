    string connectionString, queryInsert;
    string[] arrayData = new string[10];
    
    connectionString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
    queryInsert = @"
    	INSERT INTO AUStagAPITestData
    	(
    		[TestSuite], [TestCase], [Status], [Info], [Time], [IsArchived], [DateTime]
    	)
    	VALUES (
    		@TestSuite, @TestCase, @Status, @Info, @Time, @IsArchived, @DateTime
    	)
    ";
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(queryInsert, connection))
    {
    	string testSuite, testCase, status, info, time;
    
    	connection.Open();
    
    	for (int j = 1; j < arrayData.Length; j += 5)
    	{
    		testSuite = arrayData[j];
    		testCase = arrayData[j + 1];
    		status = arrayData[j + 2];
    		info = arrayData[j + 3];
    		time = arrayData[j + 4];
    
    		command.Parameters.AddWithValue("@TestSuite", testSuite);
    		command.Parameters.AddWithValue("@TestCase", testCase);
    		command.Parameters.AddWithValue("@Status", status);
    		command.Parameters.AddWithValue("@Info", info);
    		command.Parameters.AddWithValue("@Time", time);
    		command.Parameters.AddWithValue("@IsArchived", "1");
    		command.Parameters.AddWithValue("@DateTime", DateTime.Now);
    
    		command.ExecuteNonQuery();
    
    		// To Clear parameters
    		command.Parameters.Clear();
    	}
    	// no need to close a disposed object since dispose will call close 
    }
