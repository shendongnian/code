    Arm arm = ...
    var xs = new XmlSerializer(typeof(Arm));
    using (var writer = new DescriptionWriter("test.xml", Encoding.Unicode))
    {
        writer.Formatting = Formatting.Indented;
        xs.Serialize(writer, arm);
    }
