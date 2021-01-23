    // I have formatted yor XML and structured it. "root" is the the parent node. Elements are the child elements of root consisting of timestamp tag.
    
     string xmlInput =  @"
	 <root>
     <element>
     <timestamp time='2016-09-16T13:45:30'>
     </timestamp>
     </element>
	 <element>
     <timestamp time='2016-10-16T13:45:30'>
     </timestamp>
     </element>
	 </root>";
	
		XDocument  xdoc = XDocument.Parse(xmlInput);
		xdoc.Descendants("root").Elements("element").
                                 Where(x => DateTime.Compare(DateTime.Parse(x.Element("timestamp").Attribute("time").Value,null, DateTimeStyles.RoundtripKind), inputDate) ==0).
                                 ToList().ForEach(x => x.Remove());
		
