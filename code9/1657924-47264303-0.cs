            this.Manifest = new XmlDocument();
            this.Manifest.Load(manifestPath);
            XmlNode rootNode = this.Manifest.DocumentElement.SelectSingleNode("database");
            XmlNode userNameNode = rootNode.SelectSingleNode("username");
            XmlNode passwordNode = rootNode.SelectSingleNode("password");
            
        	if (userNameNode != null && passwordNode != null)
            {
                
        		this.Connector = new SqlConnector(string.Format(CONNECTION_STRING_TEMPLATE, rootNode.SelectSingleNode("server").InnerText, rootNode.SelectSingleNode("catalog").InnerText, userNameNode.InnerText, passwordNode.InnerText));
        		
            }
            else 
            {
                //Windows authentication
        		this.Connector = new SqlConnector(string.Format("Server={0};Initial Catalog={1};Integrated Security=SSPI;", rootNode.SelectSingleNode("server").InnerText, rootNode.SelectSingleNode("catalog").InnerText);
            }
