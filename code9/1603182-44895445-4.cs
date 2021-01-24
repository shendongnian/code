	Dictionary<string, string> VersionDictionary = new Dictionary<string, string>()
	{
		{ "asv1901", "American Standard Version" },
		{ "bbe", "Bible In Basic English" },
	};
	var VersionList = new List<string>();
	// keyvaluepair is a single instance and dictionary is a collection of keyvaluepairs
	foreach (KeyValuePair<string, string> version in VersionDictionary)
	{
		var key = version.Key.ToUpper();
		var value = version.Value;
		// "Bible In Basic English (BBE)"
		VersionList.Add(string.Format("{0} ({1})", value, key));
	}
