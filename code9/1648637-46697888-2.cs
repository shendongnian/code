	var links = Sitecore.Globals.LinkDatabase.GetItemReferrers(templateItem, false);
	foreach (var link in links)
	{
		if (link.SourceFieldID == Sitecore.FieldIDs.BaseTemplate)
		{
			inheritors.Add(link.SourceItemID.ToString());
		}
	}
