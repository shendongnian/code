    var id = 3;
    var message = "&'<crazyMessage&&";
    
    var xmlDoc = new XmlDocument();
    
    using(var writer = xmlDoc.CreateNavigator().AppendChild())
    {
    	writer.WriteStartElement("ROOT");
    	
    	writer.WriteElementString("ID", id.ToString());
    	
    	writer.WriteStartElement("INPUT");
    	writer.WriteElementString("ENGMSG", message);
    	writer.WriteEndElement(); // INPUT
    	
    	writer.WriteEndElement(); // ROOT
    }
    
    var xmlString = xmlDoc.InnerXml;
    Console.WriteLine(xmlString);
