	using System;
	using System.Globalization;
	namespace SO43746933
	{
		class Program
		{
			private static readonly CultureInfo NmeaCultureInfo = CultureInfo.InvariantCulture;
			static void Main(string[] args)
			{
				string input =
					"$GPRMC,081836,A,3751.65,S,14507.36,E,000.0,360.0,130998,011.3,E*62 $GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47 $GPGSA,A,3,32,27,03,193,29,23,19,16,21,31,14,,1.18,0.51,1.07*35";
				var newCoordinates = GetCoordinatesNew(input);
				var oldCoorinates = GetCoordinatesOld(input);
				if (newCoordinates == null || oldCoorinates == null)
				{
					throw new InvalidOperationException("should never throw");
				}
				Console.WriteLine("Latitude: {0}\t\tLongitude:{1}", newCoordinates.Value.Latitude, newCoordinates.Value.Longitude);
				Console.WriteLine("Latitude: {0}\t\tLongitude:{1}", oldCoorinates.Value.Latitude, oldCoorinates.Value.Longitude);
			}
			private static (double Latitude, double Longitude)? GetCoordinatesNew(string input)
			{
				// Divide the sentence into words
				var coordinateStrings = ParseCoordinatesStrings(input);
				// Do we have enough values to describe our location?
				if (coordinateStrings == null)
					return null;
				var latitude = ParseCoordinate(coordinateStrings.Value.LatitudeString);
				var longitude = ParseCoordinate(coordinateStrings.Value.LongitudeString);
				return (latitude, longitude);
			}
			private static (string LatitudeString, string LongitudeString)? ParseCoordinatesStrings(string input)
			{
				int latitudeIndex = -1;
				for (int i = 0; i < 3; i++)
				{
					latitudeIndex = input.IndexOf(',', latitudeIndex + 1);
					if (latitudeIndex < 0)
						return null;
				}
				int latitudeEndIndex = input.IndexOf(',', latitudeIndex + 1);
				if (latitudeEndIndex < 0 || latitudeEndIndex - latitudeIndex <= 1)
					return null; // has no latitude
				int longitudeIndex = input.IndexOf(',', latitudeEndIndex + 1);
				if (longitudeIndex < 0)
					return null;
				int longitudeEndIndex = input.IndexOf(',', longitudeIndex + 1);
				if (longitudeEndIndex < 0 || longitudeEndIndex - longitudeIndex <= 1)
					return null; // has no longitude
				string latitudeString = input.Substring(latitudeIndex + 1, latitudeEndIndex - latitudeIndex - 1);
				string longitudeString = input.Substring(longitudeIndex + 1, longitudeEndIndex - longitudeIndex - 1);
				return (latitudeString, longitudeString);
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
			private static (double Latitude, double Longitude)? GetCoordinatesOld(string input)
			{
				// Divide the sentence into words
				string[] Words = input.Split(',');
				// Do we have enough values to describe our location?
				if (!(Words[3] != "" && Words[4] != "" &
					  Words[5] != "" && Words[6] != ""))
					return null;
				// example 5230.5900,N
				// 52°30.5900\N
				// Yes. Extract latitude and longitude
				//Latitude decimal
				var wholeLat = double.Parse(Words[3], NmeaCultureInfo);
				int integerPart = (int)wholeLat;
				int DegreesLat = integerPart / 100;
				string[] tempLat = Words[3].Substring(2).Split('.');
				int MinutesLat = integerPart % 100;
				string SecLat = "0";
				if (tempLat.Length >= 2)
				{
					SecLat = "0." + tempLat[1];
				}
				double SecondsLat = double.Parse(SecLat, NmeaCultureInfo) * 60;
				double Latitude = (DegreesLat + (MinutesLat / 60.0) + (SecondsLat / 3600.0));
				//Longitude decimal
				double DegreesLon = double.Parse(Words[5].Substring(0, 3), NmeaCultureInfo);
				string[] tempLon = Words[5].Substring(3).ToString().Split('.');
				double MinutesLon = double.Parse(tempLon[0], NmeaCultureInfo);
				string SecLon = "0";
				if (tempLon.Length >= 2)
				{
					SecLon = "0." + tempLon[1];
				}
				double SecondsLon = double.Parse(SecLon, NmeaCultureInfo) * 60;
				double Longitude = (DegreesLon + (MinutesLon / 60) + (SecondsLon / 3600));
				return (Latitude, Longitude);
			}
		}
	}
