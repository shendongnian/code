    public int FetchYearFromCategory(string category){
	XmlDocument doc = new XmlDocument();
	doc.Load("path_to_your_file");
	XmlNodeList allBooks = doc.GetElementsByTagName("book");
	foreach (XmlNode singleBookNode in allBooks)
	{
		if(singleBookNode.Attributes["category"] != null && singleBookNode.Attributes["category"].Value.Equals(category))
		{
			XmlNodeList childNodes = singleBookNode.ChildNodes; 
			foreach (XmlNode childNode in childNodes)
			{
				if(childNode.Name.Equals("year"))
				{
					return Int32.Parse(childNode.InnerText);
				}			
			}		
		}	
	}
	return -1;}
