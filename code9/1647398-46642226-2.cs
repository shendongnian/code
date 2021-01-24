	foreach (var key in record.Attributes.Keys)
	{
		if (record.FormattedValues.ContainsKey(key))
		{
			string formattedvalue;
			if (record.FormattedValues.TryGetValue(key, out formattedvalue))
			{
				Console.WriteLine(formattedvalue); // use formattedvalue string
			}
			continue; // skip to next field when found in formatted values
		}
		object attributevalue;
		record.Attributes.TryGetValue(key, out attributevalue);
		object actualvalue;
		string actualtext = string.Empty;
		// handle AliasedValue fields from JOINed/LinkEntities
		if (attributevalue.GetType().Name == "AliasedValue")
		{
			actualvalue = ((AliasedValue)attributevalue).Value;
		}
		else
		{
			actualvalue = attributevalue;
		}
		switch (actualvalue.GetType().Name)
		{
			case "EntityReference":
				actualtext = ((EntityReference)actualvalue).Name; // this will catch Lookup values not contained in FormattedValues when you just created them
				break;
			case "DateTime":
				actualtext = string.Format("{0:dd.MM.yyyy}", ((DateTime)actualvalue).ToLocalTime()); // ... any other dateTime format you'd like
				break;
			case "Guid":
				actualtext = string.Format("{0:D}", actualvalue); // Entity Primary key
				break;
			default:
				actualtext = (string)actualvalue; // anything else
				break;
		}
		Console.WriteLine(actualtext);
	}
