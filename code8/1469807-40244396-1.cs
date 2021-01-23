    private static void Xs_UnknownElement(object sender, XmlElementEventArgs e)
    {
        var root = (Root)e.ObjectBeingDeserialized;
        if (root.Dict == null)
            root.Dict = new Dictionary<string, string>();
        root.Dict.Add(e.Element.Name, e.Element.InnerText);
    }
