       // Load the xml into XElement 
       XDocument doc = XDocument.Load("F:\\db.xml",LoadOptions.None);
	
       // Search through descendants and 
       // find one with name as MAIN
       XElement result = doc.Descendants("add")
      .FirstOrDefault(y => y.Attribute("name") != null &&
                         y.Attribute("name").Value == "MAIN");
	
        // Get the values if valid element is found  
	    if(result != null)
	    {
	      string server = (result.Attribute("server") != null) ?  result.Attribute("server").Value : string.Empty;
	      string database = (result.Attribute("database") != null) ?  result.Attribute("database").Value : string.Empty;
        }
