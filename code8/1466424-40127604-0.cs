        public static void CreateXmlFile(Instance instance, string filePath)
        {
    
           var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Product><ProductName>da</ProductName><PluginPath></PluginPath><Instances></Instances></Product>";
           
    
    
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            xmlDocument.Save(filePath);
    
            
            XmlNode xnode = xmlDocument.CreateNode(XmlNodeType.Element, "Instances", null);
            XmlSerializer xSeriz = new XmlSerializer(typeof(Instance));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlWriterSettings writtersetting = new XmlWriterSettings();
            writtersetting.OmitXmlDeclaration = true;
            StringWriter stringwriter = new StringWriter();
            using (XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter, writtersetting))
            {
                xSeriz.Serialize(xmlwriter, instance, ns);
            }
            xnode.InnerXml = stringwriter.ToString();
            XmlNode bindxnode = xnode.SelectSingleNode("Instance");
            xmlDocument.DocumentElement.SelectSingleNode("Instances").AppendChild(bindxnode);
            xmlDocument.Save(filePath);
    
        }
