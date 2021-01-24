    private static void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
    {
        if (e.NamespaceURI == "http://www.w3.org/2001/XMLSchema-instance" &&
            e.LocalName == "type")
        {
            // Ignore xsi:type attributes.
        }
        else
        {
            // [Log it...]
        }
    }
    // [And similarly for UnknownAttribute using e.Attr instead of e...]
