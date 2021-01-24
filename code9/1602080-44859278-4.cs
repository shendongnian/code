    var xs = new XmlSerializer(typeof(Root));
    Root root = null;
    StorageFolder folder = ApplicationData.Current.LocalFolder;
    using (var stream = await folder.OpenStreamForReadAsync("test.xml"))
    {
        var xml = XElement.Load(stream);
        var contacts = xml.Element("contacts");
        var dict = contacts.Elements().ToDictionary(x => x.Name.LocalName, x => x.Value);
        contacts.Remove();
        root = (Root)xs.Deserialize(xml.CreateReader());
        root.Contacts = dict;
    }
