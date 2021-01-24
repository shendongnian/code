	HashSet<string> uniqueTagList = new HashSet<string>();
	var blogItems = Umbraco.TypedContent(Model.Content.Id).Children.Where(x => x.DocumentTypeAlias == "BlogItem" && x.IsVisible());
	var tags = blogItems.Select(x => x.GetPropertyValue<string>("tagsList"));
	foreach(var tag in tags)
	{
		var splitTag = tag.Split(',');
		foreach(var singleTag in splitTag)
		{
			uniqueTagList.Add(singleTag);
		}
	}
