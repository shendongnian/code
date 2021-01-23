    public string ParseImage(string pHtml)
    {
    
       HtmlDocument doc = new HtmlDocument();
       doc.LoadHtml(pHtml);
       var imgs = doc.DocumentNode.SelectNodes("//img");
    
    	foreach (var item in imgs)
    	{
    		string orig = item.Attributes["src"].Value;
    		//Add class to each img tag.
    	}
    	using(StringWriter tw = new StringWriter ()){
    		doc.Save(tw);
    		return tw.ToString();
    	}
     }
