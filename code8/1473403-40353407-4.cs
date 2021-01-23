    XmlDocument xDoc = new XmlDocument();
    xDoc.Load(content);
    
    XmlNamespaceManager manager = new XmlNamespaceManager(xDoc.NameTable);
    manager.AddNamespace("MYNS", "http://schemas.datacontract.org/2004/07/WebApi.Models");
    
    XmlNodeList nodelist = xDoc.DocumentElement.SelectNodes("MYNS:ProductoModel", manager);
    foreach (XmlNode node in nodelist)
    {
         MessageBox.Show(node.SelectSingleNode("MYNS:descripcion", manager).InnerText);
    }
