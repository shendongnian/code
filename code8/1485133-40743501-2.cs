    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<book>" +
                        "  <title>Oberon's Legacy</title>" +
                        "  <price>5.95</price>" +
                        "</book>");
    invoices invoices = new invoices();
    invoices.Nodes = new XmlNode[2];
    invoices.Nodes[0] = doc.CreateNode("element", "test", "myNamespace");
    invoices.Nodes[1] = doc.CreateNode("element", "tes2", "myNamespace");
