    var serializer = new XmlSerializer(typeof(Example));
    var ns = new XmlSerializerNamespaces();
    // map prefix to namespace like this
    ns.Add("rd", "mynamespace");
    var ms = new MemoryStream();      
    // use namespaces while serializing
    serializer.Serialize(ms, new Example {
        Node1 = "node1",
        Node2 = "node2"
    }, ns);
