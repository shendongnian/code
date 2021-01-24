	HtmlDocument document = new HtmlDocument();
	document.Load(Server.MapPath("xpath.html"));
	// Teams
	HtmlNodeCollection teamNodes = document.DocumentNode.SelectNodes("//div[@class='ippg-Market_CompetitorName']");
	List<string> teams = new List<string>();
	foreach (HtmlNode n in teamNodes)
	{
		HtmlNode nodeTeam = n.SelectSingleNode(".//span[@class='ippg-Market_Truncator']");
		if (nodeTeam != null)
		{
			teams.Add(nodeTeam.InnerText);
		}
	}
	// Odds
	HtmlNodeCollection oddNodes = document.DocumentNode.SelectNodes("//span[@class='ippg-Market_Odds']");
	List<string> odds = new List<string>();
	foreach (HtmlNode o in oddNodes)
	{
		odds.Add(o.InnerText);
	}
