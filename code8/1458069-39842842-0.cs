    while (reader.Read())
    {
        if (reader.NodeType == XmlNodeType.Element)
        {
            switch (reader.Name)
            {
                case "tileset":
                    if (!Tilesets.Any(ts => ts.Name == reader.GetAttribute("name")))
                    {
                        // handling the image node here
                        if (reader.ReadToDescendant("image"))
                        {
                            string source = reader.GetAttribute("source");
                        }
                    }
                    break;
            }
        }
    }
