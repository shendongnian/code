		var filePath = Path.GetTempFileName();
		
		File.WriteAllText(filePath, "{bigJson: true}");
			
		var stream = File.Open(filePath, FileMode.Open);
			
		JsonTextReader reader = new JsonTextReader(new StreamReader(stream));
		while (reader.Read())
		{
			if (reader.Value != null)
			{
				Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
			}
			else
			{
				Console.WriteLine("Token: {0}", reader.TokenType);
			}
		}
