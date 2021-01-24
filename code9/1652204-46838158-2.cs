	using(SqlDataReader reader = command.ExecuteReader())
	{
		if (reader.Read())
		{
			btn.ItemID = reader.GetInt32(0);
			if(!reader.IsDBNull(1))
				btn.ItemName = reader.GetString(1);
			if(!reader.IsDBNull(2))
				btn.ItemPrice = reader.GetInt32(2);
			if(!reader.IsDBNull(3))
				btn.ItemDiscount = reader.GetFloat(3);   // Throw exception
			itemPanel.Children.Add(btn);
		}
	}
