    static void SetXaml(RichTextBox rt, string xamlString)
    {
        StringReader stringReader = new StringReader(xamlString);
        XmlReader xmlReader = XmlReader.Create(stringReader);
        Section sec = XamlReader.Load(xmlReader) as Section;
        FlowDocument doc = new FlowDocument();
        while (sec.Blocks.Count > 0)
            doc.Blocks.Add(sec.Blocks.FirstBlock);
        rt.Document = doc;
    }
