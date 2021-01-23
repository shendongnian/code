    using (var writer = new XmlTextWriter(targetPath, new UTF8Encoding(false)))
    {
        writer.Formatting = Formatting.Indented;
        dataDoc.Save(writer);
    }
