	public static DateTime ConvertToDateTime(string input, string[] inputFormats)
	{
		string[] formats = null;
		if(inputFormats == null)
		{
			formats = new string[4];
			formats[0] = "d-M-yyyy HH:mm:ss";
			formats[1] = "dd-M-yyyy HH:mm:ss";
			formats[0] = "d-M-yyyy H:mm:ss";
			formats[1] = "dd-M-yyyy H:mm:ss";
		}
		else
		{
			formats = inputFormats;
		}
		DateTime output;
		IFormatProvider provider = new CultureInfo(CultureInfo.CurrentUICulture.LCID, true);
		output = DateTime.ParseExact(input, formats, provider, DateTimeStyles.NoCurrentDateDefault);
		return output;
	}
