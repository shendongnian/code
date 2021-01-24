    var getImagesBlock = new TransformBlock<Book, Book>(async b =>
    {
        b.Images = await GetImagesAsync(b.ID);
        return b;
    }, defaultOptions);
    var getLinksBlock = new TransformBlock<Book, Book>(async b =>
    {
        b.Refs = await GetLinksReferencesAsync(b.ID);
        return b;
    }, defaultOptions);
    var getAuthorBioBlock = new ActionBlock<Book>(async b =>
    {
        b.AuthorBio = await GetAuthorBioAsync(b.ID);
    }, defaultOptions);
