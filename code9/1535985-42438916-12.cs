    // READ
    var data = System.IO.File.ReadAllText(@"C:\temp\file.xml");
    Root root;
    var serializer = new XmlSerializer(typeof(Root));
    using (var stream = new StringReader(data))
    using (var reader = XmlReader.Create(stream))
    {
        root = (Root)serializer.Deserialize(reader);
    }
    // WORK ON YOUR OBJECT.
    // TODO ...
    // WRITE
    //var root = new Root();
    root.Content = new List<Content>();
    root.Content.Add(new Content { UId = "1", FileName = "file1.jpg" });
    root.Content.Add(new Content { UId = "2", FileName = "file2.jpg" });
    //var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Root));
    serializer.Serialize(File.Create(@"C:\temp\file1.xml"), root);
