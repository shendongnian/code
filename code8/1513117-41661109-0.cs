    using(XmlReader reader = XmlReader.Create(new StreamReader("Content/Saves/SaveFile.xml", Encoding.UTF8), settings))
    {
        reader.MoveToContent();
        reader.MoveToAttribute("width");
        int w = int.Parse(reader.Value);
        reader.MoveToNextAttribute();
        int h = int.Parse(reader.Value);
    }
