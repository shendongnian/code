    var authorData = (from a in ctx.Authors
            where a.Age > 30
            select new // anon class
            {
                Name = a.Name,
                City = a.Address.City,
                Books = (from b in ctx.Books
                        where b.Price > 10
                        && b.AuthorId == a.Id
                        select new // anon class
                        {
                            Name = b.Name,
                            Price = b.Price,
                        }).ToList()
            }).ToList();
    foreach(var author in authorData)
       {
         Console.WriteLine(author.Books.Count());
       }
