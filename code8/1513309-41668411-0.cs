	HtmlDocument doc = new HtmlDocument();
	doc.Load(YourHTMLFile);
	foreach(HtmlNode Spans in doc.DocumentNode.SelectNodes("//span"))
	{
		Console.WriteLine(Spans.InnerText);
	}
