    public static IEnumerable<XElement> StreamPerson(string path)
    {
        using (XmlReader rdr = XmlReader.Create(path))
        {
            rdr.MoveToContent();
            while (rdr.Read())
            {
                XElement item = XElement.ReadFrom(rdr) as XElement;
                if (item != null)
                {
                    yield return new Person
                    {
                        FirstName = item.Element("FirstName")?.Value,
                        LastName = item.Element("LastName")?.Value
                    };
                }
            }
        }
    }
