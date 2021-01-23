	public static TEnum GetEnumValue<TEnum>(XElement x, string tag)
		where TEnum : struct
	{
		// Set default value
		TEnum parsedEnum = default(TEnum);
		
		var element = x.Element(tag);
		if(element != null)
		{
			// Try to parse
			Enum.TryParse<TEnum>(element.Value, out parsedEnum);
		}
		
		return parsedEnum;
	}
