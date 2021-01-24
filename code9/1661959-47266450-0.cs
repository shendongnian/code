    using System.Globalization;
    const string format = "yyyy-MM-dd hh:mm tt";
    CultureInfo enUS = new CultureInfo("en-US"); 
    string dateString = Eval("Date"); // e.g. "2017-11-13 02:16 PM"
		
    DateTime? result; // final result or null stored here
	DateTime parseResult;
	if (DateTime.TryParseExact(dateString, format, enUS, DateTimeStyles.None, out parseResult)) {
		result = parseResult;
	}
	else {
		result = null;
	}
		
    // check for null before displaying
	string display = result.HasValue ? result.Value.ToString(format) : "null";
