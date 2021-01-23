    public void ReadXml(XmlReader reader)
    {
      reader.ReadToDescendant("name");
      name = reader.ReadElementContentAsString();
      val = reader.ReadElementContentAsInt();
      reader.Read();
    }
