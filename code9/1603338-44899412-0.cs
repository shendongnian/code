    using (var response = await client.GetAsync(_url, HttpCompletionOption.ResponseHeadersRead))
	using (var stream = await response.Content.ReadAsStreamAsync())
	using (var streamReader = new StreamReader(stream))
	using (var reader = new JsonTextReader(streamReader))
	{
		
		var serializer = new JsonSerializer();		
		
		while (reader.Read())
		{
			switch (reader.TokenType)
			{
				case JsonToken.Start:
				// code to handle it
				break;
				case JsonToken.PropertyName:
				// code to handle it
                break;
				
				// more options	
		    }
		}		
	}
