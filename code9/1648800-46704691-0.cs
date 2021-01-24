    public override object ConvertFromString(TypeConverterOptions options, string text)
    {
    	if (string.IsNullOrEmpty(text)) return null;
    
    	DateTimeFormatInfo info = new DateTimeFormatInfo() { FullDateTimePattern = DateStringFormat };
    
    	return Convert.ToDateTime(text, info);
    }
