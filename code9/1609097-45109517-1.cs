        public XmlElement CreateGenresXml(string[] args)
        {
            var el = new XElement("Genres");
            el.Add(args.Where(x => !string.IsNullOrWhiteSpace(x)).Select(arg => new XElement("Genre", new XAttribute("Value", arg))));
            var doc = new XmlDocument();
            using (var reader = el.CreateReader())
            {
                doc.Load(reader);
            }
            return doc.DocumentElement;
        }
