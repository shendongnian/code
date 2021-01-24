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
