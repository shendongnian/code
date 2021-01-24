    var sb = new StringBuilder();
    using (var reader = XmlReader.Create("test.xml"))
    {
        while (reader.ReadToFollowing("part"))
        {
            var part = reader.ReadElementContentAsString();
            sb.Append("Part: ").AppendLine(part);
            reader.ReadToFollowing("number");
            var number = reader.ReadElementContentAsDouble();
            sb.Append("Number: ").Append(number).AppendLine();
            reader.ReadToFollowing("character");
            var character = reader.ReadElementContentAsString();
            sb.Append("Character: ").AppendLine(character);
        }
    }
    Console.WriteLine(sb);
