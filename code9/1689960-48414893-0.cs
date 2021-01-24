	private string[] splitUrl(string url)
	{
		Match match = Regex.Match(url, @"\:|\.(.{2,3}(?=/))"); // Regex Pattern
		if (match.Success)  // check if it has a valid match
		{
			string split = match.Groups[0].Value; // get the matched text
			int index = url.IndexOf(split);
			return new string[] 
			{ 
				url.Substring(0, index + split.Length),
				url.Substring(index + (split.Length), url.Length - (index + split.Length))
			};
		}
		return null;
	}
