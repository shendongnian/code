    using System.IO.Compression;
    using System.Xml;
    
    ZipArchive archive = new ZipArchive(file.OpenBinaryStream());
    var stream = archive.GetEntry(@"docProps/core.xml").Open();
    using (var reader = XmlReader.Create(stream))
    {
        for (reader.MoveToContent(); reader.Read();)
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "dcterms:created")
            {
                stream.Close();
                return DateTime.Parse(reader.ReadElementString());
            }
    }
