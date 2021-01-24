	string x = "1/1/2017";
	string y = "01/01/2017";
	DateTime dateTime;
	if (DateTime.TryParse(y, out dateTime))
	{
		Console.WriteLine($"Day = {dateTime.Day}");
		Console.WriteLine($"Month = {dateTime.Month}");
		Console.WriteLine($"Year = {dateTime.Year}");
	}
	else
	{
		Console.WriteLine("Date cannot be parsed");
	}
