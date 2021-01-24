	//...
	using System.Linq;
    using System.Xml.Linq;
	//...
	XDocument doc = XDocument.Load(@"C:\directory\file.xml");
	IEnumerable<XElement> partElements = doc.Root.Elements("part");
	foreach (XElement partElement in partElements)
	{
		// read attribute value
		string keyName = partElement.Attribute("keyName")?.Value;
		//...
		// iterate through childnodes
		foreach (XElement partChildElement in partElement.Elements())
		{
			// check the name
			if (partChildElement.Name == "SpaceSep")
			{
				int value = (int)partChildElement; // casting from element to its [int] content
				// do stuff for <SpaceSep> element
			}
			else if (partChildElement.Name == "text")
			{
				string text = (string)partChildElement; // casting from element to its [string] content
				// do stuff for <text> element
			}
			// and so on for all possible node name
		}
	}
