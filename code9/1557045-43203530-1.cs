	Type t = typeof(UserData);
    PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public|BindingFlags.Instance);
	
	
	using(StreamWriter writer = new StreamWriter("my_data.txt"))
	{
	
		foreach(var user in usersL)
		{
			
			List<object> propValues = new List<object>();
			foreach(var pi in propInfos)
			{
				propValues.Add(pi.GetValue(user, null));
			}
			
			string csvLine = String.Join(",", propValues); 
			
			writer.WriteLine(csvLine);
		}
	}
