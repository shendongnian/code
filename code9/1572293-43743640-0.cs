    public void Save(string fileName, SaveOptions options)
    {
        XmlWriterSettings ws = GetXmlWriterSettings(options);
        if (_declaration != null && !string.IsNullOrEmpty(_declaration.Encoding))
        {
            try
            {
                ws.Encoding = Encoding.GetEncoding(_declaration.Encoding);
            }
            catch (ArgumentException)
            {
            }
        }
    
        using (XmlWriter w = XmlWriter.Create(fileName, ws))
        {
            Save(w);
        }
    }
