            private static string LoadWCFConfiguration()
        {
            XmlDocument doc = null;
            Assembly currentAssembly = Assembly.GetCallingAssembly();
            string configIsMissing = string.Empty;
            string WCFEndPointAddress = string.Empty;
            string NodePath = "//system.serviceModel//client//endpoint";
            try
            {
                doc = new XmlDocument();
                doc.Load(Assembly.GetEntryAssembly().Location + ".config");
            }
            catch (Exception)
            {
                configIsMissing = "Configuration file is missing for Manager or cannot be loaded. Please create or add one and try again.";
                return configIsMissing;
            }
            XmlNode node = doc.SelectSingleNode(NodePath);
            if (node == null)
                throw new InvalidOperationException("Error. Could not find the endpoint node in config file");
            try
            {
                WCFEndPointAddress = node.Attributes["address"].Value;
            }
            catch (Exception)
            {
                
                throw;
            }
            return WCFEndPointAddress;
        }
