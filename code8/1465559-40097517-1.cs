    public static IEnumerable<string> FilterLinks(HtmlDocument doc, string regexFilter)
	{
		var regex = new Regex(regexFilter);
		return doc.DocumentNode
			.SelectNodes("//a[@href]")
			.Where(	n => n.NextSibling != null && 
					regex.IsMatch(n.GetAttributeValue("href", string.Empty)))
			.Select(n => n.GetAttributeValue("href", string.Empty));
	}
