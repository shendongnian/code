    void ParseXml(string XmlFile)
        {
            string totalval = "";
            using(XmlDocument xmldoc = new XmlDocument()) 
            {
              xmldoc.Load(new StringReader(XmlFile));
    
              string xmlPathPattern = "//name";
    
    
            XmlNodeList mynodelist = xmldoc.SelectNodes(xmlPathPattern);
            foreach (XmlNode node in mynodelist)
            {
                XmlNode name = node.FirstChild;
                name.Value = "asd";//here I am trying to change value
                totalval = totalval + "Name=" + name.OuterXml + "\n";
            }
    
            xmldoc.Save(XmlFile);
            print(totalval);
        }
    }
