	string format = "yyyy-MM-ddTHH:mm:ss";
	DateTime parsedDateTime;
	if (DateTime.TryParseExact("2017-05-01T00:00:00", format, null,
          System.Globalization.DateTimeStyles.None, out parsedDateTime))
	{
		 Console.WriteLine(parsedDateTime.ToString());
	}
	else
	{
		Console.WriteLine("FAIL");
	}
