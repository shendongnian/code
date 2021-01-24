    string doc = @"<Absolventi nume='Ace Timisoara'>
    <id>7</id>
    <oras>Timisoara</oras>
    </Absolventi>";
    XmlDocument xDoc = new XmlDocument();
    xDoc.LoadXml(doc);
    foreach (XmlNode node in xDoc.ChildNodes)
    {
    	Console.WriteLine(node.Attributes["nume"].Value);
    	Console.WriteLine(node["id"].InnerText);
    	Console.WriteLine(node["oras"].InnerText);   
    }
