	Dictionary<string, string> VersionDictionary = new Dictionary<string, string>()
	{
		{ "asv1901", "American Standard Version" },
		{ "bbe", "Bible In Basic English" },
	};
	// take the dictionary<string, string>, turn it into an ienumerable<keyvaluepair<string, string>>, use linq to output the contents, format a new string based on those contents, turn it into list<string>
	// "Bible In Basic English (bbe)"
	var VersionList = VersionDictionary.AsEnumerable().Select(x => string.Format("{0} ({1})", x.Value, x.Key)).ToList();
	VersionPicker.BindingContext = VersionList;
