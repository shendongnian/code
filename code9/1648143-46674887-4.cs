    public void ReadXml(XmlReader reader)
    {
        while (reader.Read())
        {
            if (reader.Name == "foo")
            {
                foo = (FlagsEnum)reader.ReadElementContentAsInt();
            }
        }
    }
    public void WriteXml(XmlWriter writer)
    {
        writer.WriteElementString("foo", ((int)foo).ToString());
    }
