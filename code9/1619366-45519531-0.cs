    string InsertData = "INSERT INTO AUStagAPITestData ([TestSuite], [TestCase],[Status], [Info], [Time], [IsArchived], [DateTime]) VALUES (@TestSuite, @TestCase, @Status, @Info, @Time, @IsArchived, @DateTime)";
    
    // put your connection and command into *USING* blocks to properly dispose of them
    using (SqlConnection sqlconn = new SqlConnection(sqlconnectionstring))
    using (SqlCommand Insertcmd = new SqlCommand(InsertData, sqlconn))
    {
        // create the parameters **ONCE** and define their datatypes
        // I have only *guessed* what the datatypes could be - adapt as needed
        Insertcmd.Parameters.Add("@TestSuite", SqlDbType.VarChar, 50);
        Insertcmd.Parameters.Add("@TestCase", SqlDbType.VarChar, 50);
        Insertcmd.Parameters.Add("@Status", SqlDbType.VarChar, 50);
        Insertcmd.Parameters.Add("@Info", SqlDbType.VarChar, 50);
        Insertcmd.Parameters.Add("@Time", SqlDbType.Time);
        Insertcmd.Parameters.Add("@IsArchived", SqlDbType.Boolean);
        Insertcmd.Parameters.Add("@DateTime", SqlDbType.DateTime);
    	
        sqlconn.Open();
    	
    	// now loop over the data and set the parameter values
    	for (int j = 1; j < TDData.Length; j +=5)
    	{
    		string TestSuite = TDData[j];
    		string TestCase = TDData[j+1];
    		string Status = TDData[j + 2];
    		string Info = TDData[j + 3];
    		string Time = TDData[j + 4];
    
    		Insertcmd.Parameters["@TestSuite"].Value = TestSuite;
    		Insertcmd.Parameters["@TestCase"].Value = TestCase;
    		Insertcmd.Parameters["@Status"].Value = Status;
    		Insertcmd.Parameters["@Info"].Value = Info;
    		Insertcmd.Parameters["@Time"].Value = Time;
    		Insertcmd.Parameters["@IsArchived"].Value = true;
    		Insertcmd.Parameters["@DateTime"].Value = DateTime.Now;
    
            // execute the query in the loop
    		Insertcmd.ExecuteNonQuery();
    	}	
    
        sqlconn.Close();
    }
