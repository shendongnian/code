    while (reader.Read())
    {
        if (reader.NodeType == XmlNodeType.Element && reader.LocalName.StartsWith("sibling"))
        {
            Console.Write(reader.LocalName + ": ");
            reader.Read();
            if (reader.NodeType == XmlNodeType.Text)
                Console.WriteLine(reader.ReadContentAsString());
            else
            {
                reader.ReadToFollowing("tableName");
                Console.Write(reader.LocalName + ": ");
                var tableName = reader.ReadElementContentAsString();
                Console.WriteLine($"'{tableName}'");
            }
        }
    }
