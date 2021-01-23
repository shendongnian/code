	Dictionary<string, string> customerLookup = new Dictionary<string, string>();
	using (var reader = myLookup.ExecuteReader())
	{
		int ordinalCode = reader.GetOrdinal("code");
		int ordinalCustomerText = reader.GetOrdinal("customerText");
		while (reader.Read())
		{
			//this code assumes the values returned by the reader cannot be null
			customerLookup.Add(reader.GetString(ordinalCode), reader.GetString(ordinalCustomerText))
		}
	}
