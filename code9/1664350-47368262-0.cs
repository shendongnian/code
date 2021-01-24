    public bool ReadConfigs(string config) {
            string statement = null;
            try {
                string xmlFile = File.ReadAllText(ModLoader.GetModConfigFolder(this) + "\\configs.xml");
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(xmlFile);
                XmlNodeList nodeList = xmldoc.GetElementsByTagName(config);
                string Short_Fall = string.Empty;
                foreach (XmlNode node in nodeList) {
                    statement = node.InnerText;
                }
            }
            catch {
                ModConsole.Error("Falied to load configs file!");
                statement = null;
            }
            try {
                if (statement != null) {
                    return bool.Parse(statement);
                }
                else
                    return false;
            }
            catch {
                ModConsole.Error("Invalid syntax in configs!");
                return false;
            }
        }
