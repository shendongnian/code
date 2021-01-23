    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(@"C:\zzx\Project\SM\R5.1\Harness\InBound.xml");
    var namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
    namespaceManager.AddNamespace("ns", "http://schemas.hp.com/SM/7");
    XmlNode sigNode = xmlDoc.SelectSingleNode("//ns:UpdateInboundim613Response//ns:model//ns:instance//ns:OVSCTicketID",namespaceManager);
    if (sigNode != null)
    {
    	Console.WriteLine(sigNode.InnerText);
    }
