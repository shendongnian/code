    // sample data
    var xml = @"<camera><id>1</id><name>Camera 1</name></camera>";
    // deserialization according to a native attributes
    var camera = (CamerasConfigAttrib)new XmlSerializer(typeof(CamerasConfigAttrib))
                     .Deserialize(new StringReader(xml));
    // prepare overridings
    var overrides = new XmlAttributeOverrides();
    overrides.Add(typeof (CamerasConfigAttrib), "Id",
        new XmlAttributes
        {
            XmlAttribute = new XmlAttributeAttribute("Id")
        });
    overrides.Add(typeof(CamerasConfigAttrib), "Name",
        new XmlAttributes
        {
            XmlAttribute = new XmlAttributeAttribute("name")
        });
    // serializer initiated with overridings
    var s = new XmlSerializer(typeof(CamerasConfigAttrib), overrides);
    var sb = new StringBuilder();
    s.Serialize(new StringWriter(sb), camera);
