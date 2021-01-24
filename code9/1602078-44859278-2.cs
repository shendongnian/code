    private static void Xs_UnknownElement(object sender, XmlElementEventArgs e)
    {
        if (e.Element.Name == "contacts")
        {
            var root = (Root)e.ObjectBeingDeserialized;
            root.Contacts = new Dictionary<string, string>();
            foreach (XmlNode node in e.Element.ChildNodes)
            {
                root.Contacts.Add(node.Name, node.InnerText);
            }
        }
    }
