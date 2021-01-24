    var dupa = xmlDoc
        .Descendants("book")
        .Select(x => new Book
        {
            Id = (string)x.Attribute("bookid"),
            Author = (string)x.Element("author"),
            Title = (string)x.Element("title"),
            Genre = (Genre)Enum.Parse(typeof(Genre), (string)x.Element("genre")),
            Price = (decimal)x.Element("price"),
            PublishDate = (DateTime)x.Element("publish_date"),
            Description = (string)x.Element("description"),
        }).ToList();
