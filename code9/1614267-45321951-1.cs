    public static XElement Load(XmlReader reader, LoadOptions options) {
        if (reader == null) throw new ArgumentNullException("reader");
        if (reader.MoveToContent() != XmlNodeType.Element) throw new InvalidOperationException(Res.GetString(Res.InvalidOperation_ExpectedNodeType, XmlNodeType.Element, reader.NodeType));
        XElement e = new XElement(reader, options);
        reader.MoveToContent();
        if (!reader.EOF) throw new InvalidOperationException(Res.GetString(Res.InvalidOperation_ExpectedEndOfFile));
        return e;
    }
