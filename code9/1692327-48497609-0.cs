    public static void WriteKey(String configFileName, String key, String value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(configFileName);
            XmlNode node = doc.SelectSingleNode("//quartz");
            if (node == null)
            {
                throw new InvalidOperationException("quartz section not found in config file.");
            }
            try
            {
                XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));
                if ((elem != null))
                {
                    elem.SetAttribute("value", value);
                }
                else
                {
                    elem = doc.CreateElement("add");
                    elem.SetAttribute("key", key);
                    elem.SetAttribute("value", value);
                    node.AppendChild(elem);
                }
                doc.Save(configFileName);
            }
            catch
            {
                throw new InvalidOperationException("Error writing config file");
            }
        }
