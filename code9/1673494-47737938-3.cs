    var serializer = new XmlSerializer(typeof(Example));
    var ns = new XmlSerializerNamespaces();
    // map prefix to namespace like this
    ns.Add("rd", "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner");
    var ms = new MemoryStream();      
    // use namespaces while serializing
    serializer.Serialize(ms, new Example {
        Node1 = "node1",
        Node2 = "node2"
    }, ns);
