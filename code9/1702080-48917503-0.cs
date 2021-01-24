    // Get the XML namespace of the root element.
    var namespaceURI = xmlDoc.DocumentElement.NamespaceURI;
    // Create the subsystem in the same XML namespace
    var subsystem = xmlDoc.DocumentElement.AppendChild(xmlDoc.CreateElement("subsystem", namespaceURI));
    // Add the specified attributes.
    subsystem.Attributes.Append(xmlDoc.CreateAttributeWithValue("name", "hahaha"));
    subsystem.Attributes.Append(xmlDoc.CreateAttributeWithValue("tag1", "NoNo"));
    subsystem.Attributes.Append(xmlDoc.CreateAttributeWithValue("tag2", "SoNo"));
