    public IEnumerable<string> findValues(string item1, string item2)
    {
    	config = XDocument.Parse(XML_Text)
    	var res = config.Descendants("item_type1")
                        .Where(x=>x.Attribute("name").Value == item1)
                        .Descendants("item_type2")
                        .Where(x=>x.Attribute("name").Value == item2);
    	return res.Descendants("property").Select(x=>x.Value);
    }
