    private void CreateXml()
            {
                var document = new XmlDocument();
                XmlNode rootNode = document.CreateElement("Credentials");
                document.AppendChild(rootNode);
    
                rootNode.AppendChild(document.CreateElement("EncryptionKey"));
                rootNode.AppendChild(document.CreateElement("SaltKey"));
                rootNode.AppendChild(document.CreateElement("VIKey"));
                rootNode.AppendChild(document.CreateElement("EmailUsername"));
                rootNode.AppendChild(document.CreateElement("EmailPassword"));
    
                document.CreateElement("EmailPassword");
                document.Save("Credentials.xml");
            }
