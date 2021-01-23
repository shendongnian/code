    private static void Run()
    {
    	HtmlDocument brPage = new HtmlWeb().Load("http://us.desert-operations.com/world2/battleReport.php?code=f8d77b1328c8ce09ec398a78505fc465");
    	var nodes = brPage.DocumentNode.Descendants("table").Where(_ => _.Attributes["class"] != null && _.Attributes["class"].Value != null && _.Attributes["class"].Value.Contains("battleReport"));
    	string result = "";
    	List<brContentSaver> ContentList = new List<brContentSaver>();
    	foreach (var item in nodes)
    	{
    		if (item.Descendants("th").Any(_ => _.InnerText.Equals("Weapons")))
    		{
    			//get all tr nodes except first one (header)
    			var trNodes = item.Descendants("tr").Skip(1);
    			foreach (var node in trNodes)
    			{
    				brContentSaver cL = new brContentSaver();
    				var tds = node.Descendants("td").ToArray();
    				/*  Here comes the junk handler, replaces all junk for nothing, essentially deleting it
    					I wish I knew a way to do this efficiently  */
    				cL.Weapons = tds[0].InnerText
    					.Replace("&nbsp;*&nbsp;", " ")
    					.Replace("&nbsp ; *&nbsp ;", " ");
    
    				cL.Used = tds[1].Descendants("span").FirstOrDefault()?.InnerText
    					.Replace("&nbsp;*&nbsp;", " ")
    					.Replace("&nbsp ; *&nbsp ;", " ");
    				if (string.IsNullOrEmpty(cL.Used))
    				{
    					cL.Used = tds[1].InnerText;
    				}
    
    				cL.Survived = tds[2].Descendants("span").FirstOrDefault()?.InnerText
    					.Replace("&nbsp;*&nbsp;", " ")
    					.Replace("&nbsp ; *&nbsp ;", " ");
    
    				if (string.IsNullOrEmpty(cL.Survived))
    				{
    					cL.Casualties = cL.Used;
    				}
    				else
    				{
    					/*  int Casualties = int.Parse(cL.Casualties);
    					 *  int Used = int.Parse(cL.Used);
    					 *  int Survived = int.Parse(cL.Survived);
    
    					 *  Casualties = Used - Survived;   */
    
    					cL.Casualties = tds[3].Descendants("span").FirstOrDefault()?.InnerText
    					.Replace("&nbsp;*&nbsp;", " ")
    					.Replace("&nbsp ; *&nbsp ;", " ");
    
    					if (string.IsNullOrEmpty(cL.Casualties))
    					{
    						cL.Casualties = tds[3].InnerText;
    					}
    				}
    
    				ContentList.Add(cL);
    			}
    		}
    	}
    
    	foreach (var item in ContentList)
    	{
    		result += item.Weapons + " " + item.Used + " " + item.Survived + " " + item.Casualties + Environment.NewLine;
    	}
    	var text = result;
    
    }
