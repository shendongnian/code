    private static void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
    {
        if (e.NamespaceURI == XmlSchema.InstanceNamespace && e.LocalName == "type")
        {
            // Ignore xsi:type attributes.
        }
        else
        {
            // [Log it...]
        }
    }
    // [And similarly for UnknownAttribute using e.Attr instead of e...]
