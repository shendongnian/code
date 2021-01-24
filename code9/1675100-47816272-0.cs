    foreach (var book in books)
    {
        var imagesTask = GetImagesAsync(book.ID);
        var refsTask = GetLinksReferencesAsync(book.ID);
        var authorTask = GetAuthorBioAsync(book.ID);
        Task.WaitAll(imagesTask, refsTask, authorTask);
        book.Images = imagesTask.Result;
        book.Refs = refsTask.Result;
        book.AuthorBio = authorTask.Result;
    }
