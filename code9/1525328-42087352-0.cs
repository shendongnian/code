    XDocument doc;
    using (var stream = await file.OpenStreamForReadAsync())
    {
        doc = XDocument.Load(stream);
    }
    var signals = doc.Descendants("signals").Single();
    signals.Add(new XElement("Character", ...));
    using (var stream = await file.OpenStreamForWriteAsync())
    {
        stream.SetLength(0);
        doc.Save(stream);
    }
