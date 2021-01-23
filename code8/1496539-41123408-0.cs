	public static List<DateTime> ParseAmbiguousDate(string str)
	{
		var result = new List<DateTime>();
		DateTime d;
		if (str.Length == 8)
		{
			if (DateTime.TryParseExact(str, "yyyymmdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out d))
			{
				result.Add(d);
				return result;
			}
		}
		else if (str.Length == 7)
		{
			var str1 = str.Insert(4, "0");
			if (DateTime.TryParseExact(str1, "yyyyMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out d))
			{
				result.Add(d);
			}
			var str2 = str.Insert(6, "0");
			if (DateTime.TryParseExact(str2, "yyyyMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out d))
			{
				result.Add(d);
			}
		}
		return result;
	}
