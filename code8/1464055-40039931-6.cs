    var serializer = new XmlSerializer(typeof(Person));
    using (var rdr = XmlReader.Create(path))
    {
        rdr.MoveToContent();
        while (rdr.Read())
        {
            if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "Person")
            {
                yield return (Person) serializer.Deserialize(rdr);
            }
        }
    }
