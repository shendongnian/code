    public static void StoreCustomerIntoXML(string Id)
    {    
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Customers\\CustomersListCreated.xml";
    
    
            XmlDocument xmlDoc;
            if (File.Exists(reportPath))             
                 xmlDoc = XDocument.Load(reportPath); 
            else
                 xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("Customers");
            xmlDoc.AppendChild(rootNode);
    
            XmlNode userNode = xmlDoc.CreateElement("Id");
            userNode.InnerText = Id;
            rootNode.AppendChild(userNode);
    
           xmlDoc.Save(reportPath);
    }
