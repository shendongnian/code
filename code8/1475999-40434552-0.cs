        public static string FindValue(string qualifier, string xml)
        {
            var value = string.Empty;
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            XmlNode root = doc.DocumentElement;
            XmlNode identifier = root.SelectSingleNode(@"descendant::Details/Identifier [@Qualifier='" + qualifier +"']");
            value = identifier.Attributes["Value"].Value;
            return value;
        }
