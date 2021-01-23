    //Option 1
    XDocument xdoc1 = new XDocument();
    xdoc1.Add(new XElement("Text",
        Infos.Select(item => new XElement("Info",
            new XAttribute("name", item.Name),
            new XAttribute("language", item.Language),
            item.Value
            )
        )
    ));
    //Option 2
    XDocument xdoc2 = new XDocument();
    xdoc2.Add(new XElement("Text", new object[] {
        Infos.Select(item => new XElement("Info", new object[] {
            new XAttribute("name", item.Name),
            new XAttribute("language", item.Language),
            item.Value
        }))
    }));
