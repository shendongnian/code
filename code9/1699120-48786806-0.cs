	DateTime resultDate;
	string input = "24.24.2000";
	string format = "dd.MM.yyyy";
	
	if(!DateTime.TryParseExact(input, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out resultDate))
		resultDate = new DateTime(2000,01,01);
