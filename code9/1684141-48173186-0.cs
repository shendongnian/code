    List<double> doubles = new List<double>();
	
	MatchCollection matches = Regex.Matches(buff, @"(([-]|[+])?\d+(.\d+)?)");  
	foreach (Match match in matches)
	{
		string val = match.Groups[1].Value;
		doubles.Add(double.Parse(val, System.Globalization.CultureInfo.InvariantCulture));
	}
	
