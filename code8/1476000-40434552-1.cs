        public static string FindValue(string qualifier, string xml)
        {
            var value = string.Empty;
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            XmlNode identifier = null;
            XmlNode root = doc.DocumentElement;
            if (root != null)
                identifier = root.SelectSingleNode(@"descendant::Details/Identifier [@Qualifier='" + qualifier +"']");
            if (identifier?.Attributes != null) value = identifier.Attributes["Value"].Value;
            return value;
        }
