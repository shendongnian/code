    public static bool enableWebSocket()
    {
        System.Configuration.Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/my-apps-name-under-my-iis-site");
        System.Configuration.ConfigurationSection webServerSection = webConfig.GetSection("system.webServer");
        //This was the "magic" discovery. Just get the whole bunch as raw XML for manual editing:                
        XmlDocument webServerXml = new XmlDocument();
        webServerXml.LoadXml(webServerSection.SectionInformation.GetRawXml());
        //Check if the line is already there:
        XmlNodeList nodes = webServerXml.GetElementsByTagName("webSocket");
        if (nodes.Count > 0)
        {
          return false; //Already there, do nothing...
        }
        else //Node not yet found, so let's add it:
        {
            //Create a new XmlNode with the needed attributes:
            XmlNode webSocket = webServerXml.CreateNode(XmlNodeType.Element, "webSocket", null);
            XmlAttribute attr = webServerXml.CreateAttribute("enabled");
            attr.Value = "true";
            webSocket.Attributes.Append(attr);
            attr = webServerXml.CreateAttribute("pingInterval");
            attr.Value = "00:00:10";
            webSocket.Attributes.Append(attr);
            
            //Append original <system.webServer> section with the new XmlNode:
            webServerXml.DocumentElement.AppendChild(webSocket);
            
            //And finally store the modified <system.webServer> section in Web.config:    
            webServerSection.SectionInformation.SetRawXml(webServerXml.OuterXml);
            webConfig.Save();
            return true; //All done!
        }
    }
