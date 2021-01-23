        void ModifyConfig(string filepath, string xpath, string newValue)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(filepath);
            System.Xml.XmlNode elementToReplace = doc.DocumentElement.SelectSingleNode(xpath);
            elementToReplace.InnerText = newValue;
            doc.Save(filepath);
        }
