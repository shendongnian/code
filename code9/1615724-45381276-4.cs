    var bases = new List<Base>();
    using (var xmlReader = XmlReader.Create("test.xml"))
    {
        while (xmlReader.Read())
        {
            if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Base"))
            {
                var name = xmlReader.GetAttribute("Name");
                int count = 0;
                using (var innerReader = xmlReader.ReadSubtree())
                {
                    while (innerReader.Read())
                    {
                        if (innerReader.NodeType == XmlNodeType.Element && innerReader.Name == "Book")
                            count++;
                    }
                }
                bases.Add(new Base { Name = name, Count = count });
            }
        }
    }
