    XDocument xdoc = XDocument.Load("File.xml");
            var result = xdoc.Element("Doc")
            .Elements()
            .OrderBy(s => (int)s.Attribute("data"));
            string xmlOutPut = string.Empty;
            result.ToList().ForEach(a =>
            {
                xmlOutPut += a;
            });
