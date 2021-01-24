	foreach (var item in templateItems)
	{
		var baseTemplates = new TemplateItem(item).BaseTemplates.ToList();
		foreach (var baseTemplate in baseTemplates)
		{
			if (baseTemplate.ID == templateItem.ID)
			{
				inheritors.Add(item.ID.ToString());
			}
		}
	}
