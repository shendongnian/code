        private string parseXML(string name)
        {
            XDocument xmlDoc = XDocument.Load("C:\\t\\2.txt");
            var node = xmlDoc
                .Element("configuration")
                .Element("applicationSettings")
                .Element("WebApptNotificationService.Properties.Settings")
                .Elements("setting").FirstOrDefault(x => (string) x.Attribute("name") == name);
            return node.Value;
        }
