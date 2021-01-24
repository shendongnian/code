	// declare the SqlDataReader, which is used in
	// both the try block and the finally block
	SqlDataReader rdr = null;
	// create a connection object
	SqlConnection conn = new SqlConnection("Your connection string");
	// create a command object
	SqlCommand cmd = new SqlCommand("Your sql statement", conn);
	try
	{
		// open the connection
		conn.Open();
		// 1. get an instance of the SqlDataReader
		rdr = cmd.ExecuteReader();
		while(rdr.Read())
		{
			// get the results of each column
			string contact = (string)rdr["YourField1"];
			string company = (string)rdr["YourField2"];
		}
	}
	finally
	{
		// 3. close the reader
		if(rdr != null)
		{
			rdr.Close();
		}
		// close the connection
		if(conn != null)
		{
			conn.Close();
		}
	}
