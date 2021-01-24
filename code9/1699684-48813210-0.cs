    var dateString = "2018/2/9 PM 03:55:17";
	DateTime dateExact = default(DateTime);
	var result = DateTime.TryParseExact(dateString, "yyyy/M/d tt HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateExact);
	
	System.Console.WriteLine(result.ToString());
	System.Console.WriteLine(dateExact.ToString());
