    var obj = new Outer<Inner> { Property = new Inner { SomeString = "abc" } };
    var ns = new XmlSerializerNamespaces();
    ns.Add("", "");
    ns.Add("ns", "myNamespace");
    ser.Serialize(Console.Out, obj, ns);
