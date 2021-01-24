    XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("XMLFile1.xml");
            XmlNode oRootNode = xmlDocument.SelectSingleNode("/all");
            foreach (XmlNode item in oRootNode.ChildNodes)
            {
                var Kod = item?.Attributes["k"]?.InnerText;
                var Ad = item?.InnerText;
                Console.WriteLine(Kod + " " + Ad);
            }
