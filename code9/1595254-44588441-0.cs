	public static DateTime ConvertToDateTime(string input, string[] inputFormats)
	{
		string[] formats = null;
		if(inputFormats == null)
		{
			formats = new string[2];
			formats[0] = "d-M-yyyy HH:mm:ss";
			formats[1] = "d-M-yyyy HH:mm:ss";
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
