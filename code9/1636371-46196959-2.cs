    XDocument xdoc = XDocument.Load("XMLFile2.xml");
            string xmlOutPut = string.Empty;
            xdoc.Element("Doc")
              .Elements()
              .OrderBy(s => (int)s.Attribute("data"))
             .ToList().ForEach(a =>
             {
                 xmlOutPut += a;
             });
