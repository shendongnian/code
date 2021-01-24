	List<string> listOfStrings = new List<string>();
	using (var userDefaults = NSUserDefaults.StandardUserDefaults)
	using (var nsArray = userDefaults.ValueForKey(new NSString("MyAppsValues")) as NSArray)
	{
		for (uint i = 0; i < nsArray.Count; i++)
		{
			var cSharpStr = nsArray.GetItem<NSString>(i).ToString();
			listOfStrings.Add(cSharpStr);
		}
	}
