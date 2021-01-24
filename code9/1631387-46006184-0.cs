	// leave your datatypes as-is, no conversions
	string first = user1.FirstName;
	string last = user1.LastName;
	string ticket = user1.Ticket;
	int age = user1.Age;
	
	// property dispose of your sql connection and commands; 
	// they implement IDisposable so you should be using a using
	
	using (var conn = new SqlConnection("Data source=(local); Database=TicketingVoting;User Id=****;Password=****"))
	{
		try
		{
			conn.Open();
			
			SqlCommand insertdata = new SqlCommand(null, conn);
			
			insertdata.CommandText = "Insert into [TicketingVoting].dbo.Registration1 (FirstName,LastName,Age,Ticket) VALUES (@fname, @lname, @age, @ticket);"
			
			insertdata.Parameters.Add("@fname", SqlDbType.VarChar, 30).Value = first;
			insertdata.Parameters.Add("@lname", SqlDbType.VarChar, 30).Value = last;
			insertdata.Parameters.Add("@age", SqlDbType.Int).Value = age;
			insertdata.Parameters.Add("@ticket", SqlDbType.VarChar, 30).Value = ticket;
			
			insertdata.Prepare(); // prepare the statement
			insertdata.ExecuteNonQuery();
			
			Console.WriteLine("Inserting Data Successfully");
		}
		catch (Exception e)
		{
			Console.WriteLine("Exception Occur while creating table:" + e.Message + "\t" + e.GetType());
		}
    }
