    const string FORMAT = "&red;&green;&blue;";
    var format = new ColorFormat
    {
        Name = "HexFormat",
        ColorBase = "Hex",
        Format = FORMAT
    };
    var serializer = new XmlSerializer(typeof(ColorFormat));
    using (var writer = new StringWriter())
    {
        serializer.Serialize(writer, format);
        Console.WriteLine(writer.ToString());
    }
