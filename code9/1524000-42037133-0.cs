        There is one change in your code.
        Replace the line 
    XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//ns1:getCustomersResponse/getCustomersReturn", xmlNamespaceManager);
    with the below line 
    XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//ns1:getCustomersResponse/getCustomersReturn/getCustomersReturn", xmlNamespaceManager);
    
     
        Use the below code it will give you the desired output
        
        XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(result);  //loading soap message as string
                    XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
        
                    xmlNamespaceManager.AddNamespace("ns1", "http://DefaultNamespace");
        
                    XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//ns1:getCustomersResponse/getCustomersReturn/getCustomersReturn", xmlNamespaceManager);
        
                    string[] results = new string[xmlNodeList.Count];
        
                    var str = "";
                    var count = 0;
                    foreach (XmlNode xmlNode in xmlNodeList)
                    {
                        str += xmlNode.InnerText;
                    }
        
                    Assert.IsNull(results, xmlNodeList.Count + ", " + count + ", " + str);
