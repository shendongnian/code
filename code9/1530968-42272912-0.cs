    public static void StoreCustomerIntoXML(string Id)
        {
    
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "CustomersListCreated.xml";
    
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(reportPath))
            {
                xmlDoc.Load(reportPath);
                XmlNode rootNode = xmlDoc.DocumentElement;
                xmlDoc.AppendChild(rootNode);
                XmlElement elem = xmlDoc.CreateElement("Id");
                elem.InnerText = Id;
                rootNode.AppendChild(elem);
            }
            else
            {                
                XmlNode rootNode = xmlDoc.CreateElement("Customers");
                xmlDoc.AppendChild(rootNode);
                XmlNode userNode = xmlDoc.CreateElement("Id");
                userNode.InnerText = Id;
                rootNode.AppendChild(userNode);
            }   
            xmlDoc.Save(reportPath);
        }
