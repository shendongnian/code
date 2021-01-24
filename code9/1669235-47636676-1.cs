    using (var stream = new MemoryStream())
    {
        using (var writer = new XmlTextWriter(stream, Encoding.UTF8))
        {
            doc2.Save(writer);
        }
        string xml = escape_string(Encoding.UTF8.GetString(stream.ToArray()), 1);
        File.WriteAllBytes(target_xml_file, Encoding.UTF8.GetBytes(xml));
    }
