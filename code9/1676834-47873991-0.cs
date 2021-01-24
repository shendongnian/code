    select new BookDetails
    {
        BookId = b.BookId,
        BookDescription = b.BookDescription,
        BookName = b.BookName,
        AuthorId = b.AuthorID,
        BookGroupId = b.BookGroupID,
        AuthorName = a.AuthorName,
        BookGroupName = bg.BookGroupName
    }).ToList();
