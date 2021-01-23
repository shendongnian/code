    using (XmlReader reader = XmlReader.Create(stream))
    {
        reader.ReadToFollowing("book");
        reader.ReadToFollowing("author", "uri1");
        var author = reader.ReadElementContentAsString();
        Console.WriteLine(author);
        reader.ReadToFollowing("rating", "uri1");
        var rating = reader.ReadElementContentAsInt();
        Console.WriteLine(rating);
        // and so on
    }
