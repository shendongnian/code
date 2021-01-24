            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            var dups = xmlDoc.FirstChild.ChildNodes
                .Cast<XmlNode>()
                .Where(n=>n.Attributes.Count>0)
                .GroupBy(n => n.Attributes["EmailID"].Value)
                .Where(g => g.Count() > 1)
                .SelectMany(g => g.ToList())
                .ToList();
