    var assembly = typeof(TestClass).GetTypeInfo().Assembly;
    Stream stream = assembly.GetManifestResourceStream(“PrjectName.FileName”);
    using (var reader = new System.IO.StreamReader(stream))
    {
        var serializer = new XmlSerializer(typeof(List<BuildOptions>)); var listData = (List<T>)serializer.Deserialize(reader);
    }
