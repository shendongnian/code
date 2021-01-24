    var someReturnObject = new ResultObject();
	using (var context = new LinqPadDbContext(@"Server=localhost\SQLEXPRESS;Database=StackOverflow;Trusted_Connection=True;"))
	{
		var cmd = context.Database.Connection.CreateCommand();
		cmd.CommandText = "[dbo].[GetSomeData]";
		
		try
		{	        
			context.Database.Connection.Open();
			
			var reader = cmd.ExecuteReader();
			
			var result1 = ((IObjectContextAdapter)context).ObjectContext.Translate<string>(reader);
			
			someResultObject.Text1 = result1.First();
			
            //for each extra result, start here
			reader.NextResult();
			
			var users = ((IObjectContextAdapter)context).ObjectContext.Translate<User>(reader);
			
			someResultObject.Users = users.Select(x => x);
            //stop here
		}
		finally
		{
			context.Database.Connection.Close();
		}
	} 
