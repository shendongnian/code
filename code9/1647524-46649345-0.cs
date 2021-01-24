    public void ReadXml(XmlReader reader)
    {
        if (reader.MoveToContent() == XmlNodeType.Element)
        {
            Attrib1 = reader.GetAttribute("a1");
            Attrib2 = reader.GetAttribute("a2");
            Attrib3 = reader.GetAttribute("a3");
        }
        // Go to the next node.
        reader.Read();
    }
