	private static (double Latitude, double Longitude)? GetCoordinates(string input)
	{
		// Divide the sentence into words
		string[] words = input.Split(',');
		// Do we have enough values to describe our location?
		if (words[3] == "" || words[4] == "" || words[5] == "" || words[6] == "")
			return null;
		var latitude = ParseCoordinate(words[3]);
		var longitude = ParseCoordinate(words[5]);
		return (latitude, longitude);
	}
	private static double ParseCoordinate(string coordinateString)
	{
		double wholeValue = double.Parse(coordinateString, NmeaCultureInfo);
		int integerPart = (int) wholeValue;
		int degrees = integerPart / 100;
		int minutes = integerPart % 100;
		double seconds = (wholeValue - integerPart) * 60;
		return degrees + minutes / 60.0 + seconds / 3600.0;
	}
