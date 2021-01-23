	var formats = (from CultureInfo ct in CultureInfo.GetCultures(CultureTypes.AllCultures)
				   select ct.DateTimeFormat);
	string dateString = "20/06/2016 11:52";
	DateTime temp = new DateTime(0);
	foreach (DateTimeFormatInfo dfi in formats)
	{
		if (DateTime.TryParseExact(dateString, dfi.GetAllDateTimePatterns(), dfi, DateTimeStyles.None, out temp))
		{
			break;
		}
	}
	if(temp == new DateTime(0))
	{
		//save string to get it's format
	}
