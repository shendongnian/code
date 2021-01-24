    xml.Read();
    while (! xml.EOF)
    {
        if (xml.LocalName == "entry" && xml.NodeType == XmlNodeType.Element)
        {
            //using (var subtree = xml.ReadSubtree())
            {                    
                var element = (XElement)XNode.ReadFrom(xml);
                data.Add(element.Value);
            }
        }
        else
        {
            xml.Read();
        }
    }
