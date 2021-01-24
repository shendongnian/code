    string ns = "http://www.w3.org/2001/XMLSchema";
    using (var writer = XmlWriter.Create("data.xsd", writerSettings))
    {
        writer.WriteStartElement("xs", "schema", ns);
        writer.WriteStartElement("xs", "element", ns);
        writer.WriteAttributeString("name", "Table");
        writer.WriteStartElement("xs", "complexType", ns);
        writer.WriteStartElement("xs", "sequence", ns);
        writer.WriteStartElement("xs", "any", ns);
        writer.WriteAttributeString("processContents", "skip");
        writer.WriteAttributeString("maxOccurs", "unbounded");
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteStartElement("xs", "attribute", ns);
        writer.WriteAttributeString("name", "recCount");
        writer.WriteAttributeString("default", count.ToString()); // <--
        writer.WriteEndElement();
        writer.WriteStartElement("xs", "attribute", ns);
        writer.WriteAttributeString("name", "recLength");
        writer.WriteAttributeString("default", length.ToString()); // <--
        writer.WriteEndElement();
    }
